using System;
using System.IO;
using System.Text;

public class ReceivablePacket {

    private MemoryStream memoryStream;

    public ReceivablePacket(byte[] bytes)
    {
        memoryStream = new MemoryStream(bytes);
    }

    public string ReadString()
    {
        return Encoding.UTF8.GetString(ReadBytes(memoryStream.ReadByte()));
    }

    public byte[] ReadBytes(int length)
    {
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)memoryStream.ReadByte();
        }
        return result;
    }

    public int ReadByte()
    {
        return memoryStream.ReadByte();
    }

    public int ReadShort()
    {
        byte[] byteArray = new byte[2];
        byteArray[0] = (byte)memoryStream.ReadByte();
        byteArray[1] = (byte)memoryStream.ReadByte();
        return BitConverter.ToInt16(byteArray, 0);
    }

    public int ReadInt()
    {
        byte[] byteArray = new byte[4];
        byteArray[0] = (byte)memoryStream.ReadByte();
        byteArray[1] = (byte)memoryStream.ReadByte();
        byteArray[2] = (byte)memoryStream.ReadByte();
        byteArray[3] = (byte)memoryStream.ReadByte();
        return BitConverter.ToInt32(byteArray, 0);
    }

    public long ReadLong()
    {
        byte[] byteArray = new byte[8];
        byteArray[0] = (byte)memoryStream.ReadByte();
        byteArray[1] = (byte)memoryStream.ReadByte();
        byteArray[2] = (byte)memoryStream.ReadByte();
        byteArray[3] = (byte)memoryStream.ReadByte();
        byteArray[4] = (byte)memoryStream.ReadByte();
        byteArray[5] = (byte)memoryStream.ReadByte();
        byteArray[6] = (byte)memoryStream.ReadByte();
        byteArray[7] = (byte)memoryStream.ReadByte();
        return BitConverter.ToInt64(byteArray, 0);
    }

    public float ReadFloat()
    {
        byte[] byteArray = new byte[4];
        byteArray[0] = (byte)memoryStream.ReadByte();
        byteArray[1] = (byte)memoryStream.ReadByte();
        byteArray[2] = (byte)memoryStream.ReadByte();
        byteArray[3] = (byte)memoryStream.ReadByte();
        return BitConverter.ToSingle(byteArray, 0);
    }

    public double ReadDouble()
    {
        byte[] byteArray = new byte[8];
        byteArray[0] = (byte)memoryStream.ReadByte();
        byteArray[1] = (byte)memoryStream.ReadByte();
        byteArray[2] = (byte)memoryStream.ReadByte();
        byteArray[3] = (byte)memoryStream.ReadByte();
        byteArray[4] = (byte)memoryStream.ReadByte();
        byteArray[5] = (byte)memoryStream.ReadByte();
        byteArray[6] = (byte)memoryStream.ReadByte();
        byteArray[7] = (byte)memoryStream.ReadByte();
        return BitConverter.ToDouble(byteArray, 0);
    }
}
