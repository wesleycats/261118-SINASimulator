using Boo.Lang.Runtime.DynamicDispatching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    // Network manager instance.
    public static NetworkManager instance;

    // Connection settings.
    string serverIP = "127.0.0.1";
    int serverPort = 880;
    int connectionTimeOut = 5000;

    // For socket read.
    Thread readThread;
    bool readThreadStarted = false;

    // For socket write.
    Socket socket;
    bool socketConnected = false;

    private void Start()
    {
        instance = this;

        bool connect = ConnectToServer();

        Debug.Log(connect);

        ChannelSend(new EnterServerRequest());
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnApplicationQuit()
    {
        DisconnectFromServer();
    }

    public void DisconnectFromServer()
    {
        if (socket != null && socket.Connected)
        {
            socket.Close();
        }
        socketConnected = false;
        readThreadStarted = false;
    }

    // Best to call this only once per login attempt.
    public bool ConnectToServer()
    {
        if (socketConnected = false || socket == null || !socket.Connected)
        {
            ConnectSocket();
        }
        return SocketConnected();
    }

    private void ConnectSocket()
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(serverIP, serverPort, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(connectionTimeOut, true);

            if (!success)
            {
                socketConnected = false;
                socket.Close();
            }
            else
            {
                if (socket.Connected)
                {
                    socketConnected = true;
                    // Start Receive thread.
                    readThreadStarted = true;
                    readThread = new Thread(new ThreadStart(ChannelRead));
                    readThread.Start();
                }
                else
                {
                    socketConnected = false;
                    socket.Close();
                }
            }
        }
        catch (SocketException se)
        {
            socketConnected = false;
            readThreadStarted = false;
            Debug.Log(se);
        }
    }

    private void ChannelRead()
    {
        byte[] bufferLength = new byte[2]; // We use 2 bytes for short value.
        byte[] bufferData;
        short length; // Since we use short value, max length should be 32767.

        while (readThreadStarted)
        {
            if (socket.Receive(bufferLength) > 0)
            {
                // Get packet data length.
                length = BitConverter.ToInt16(bufferLength, 0);
                bufferData = new byte[length];

                // Get packet data.
                socket.Receive(bufferData);

                // Handle packet.
                ReceivablePacketManager.handle(new ReceivablePacket(Encryption.Decrypt(bufferData)));
            }
        }
    }

    public void ChannelSend(SendablePacket packet)
    {
        if (SocketConnected())
        {
            socket.Send(Encryption.Encrypt(packet.GetSendableBytes()));
        }
        else // Connection closed.
        {
            DisconnectFromServer();
            // Go to login screen.
            //  SceneFader.Fade("LoginScreen", Color.white, 0.5f);
        }
    }

    private bool SocketConnected()
    {
        // return !(socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0);
        return socketConnected && socket != null && socket.Connected;
    }
}