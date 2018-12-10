using System;
using System.IO;
using System.Text;

public class SendablePacket {

    private MemoryStream memoryStream;

    public SendablePacket()
    {
        memoryStream = new MemoryStream();
    }

    public void WriteString(String value)
    {
        if (value != null)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            WriteByte(byteArray.Length);
            WriteBytes(byteArray);
        }
        else
        {
            memoryStream.WriteByte(0);
        }
    }

    public void WriteBytes(byte[] byteArray)
    {
        for (int i = 0; i < byteArray.Length; i++)
        {
            memoryStream.WriteByte(byteArray[i]);
        }
    }

    public void WriteByte(int value)
    {
        memoryStream.WriteByte((byte)value);
    }

    public void WriteShort(int value)
    {
        memoryStream.WriteByte((byte)value);
        memoryStream.WriteByte((byte)(value >> 8));
    }

    public void WriteInt(int value)
    {
        memoryStream.WriteByte((byte)value);
        memoryStream.WriteByte((byte)(value >> 8));
        memoryStream.WriteByte((byte)(value >> 16));
        memoryStream.WriteByte((byte)(value >> 24));
    }

    public void WriteLong(long value)
    {
        memoryStream.WriteByte((byte)value);
        memoryStream.WriteByte((byte)(value >> 8));
        memoryStream.WriteByte((byte)(value >> 16));
        memoryStream.WriteByte((byte)(value >> 24));
        memoryStream.WriteByte((byte)(value >> 32));
        memoryStream.WriteByte((byte)(value >> 40));
        memoryStream.WriteByte((byte)(value >> 48));
        memoryStream.WriteByte((byte)(value >> 56));
    }

    // TODO: WriteFloat (SingleToInt32Bits)
    // public void WriteFloat(float fvalue)
    // {
    // long value = BitConverter.SingleToInt32Bits(fvalue);
    // memoryStream.WriteByte((byte)value);
    // memoryStream.WriteByte((byte)(value >> 8));
    // memoryStream.WriteByte((byte)(value >> 16));
    // memoryStream.WriteByte((byte)(value >> 24));
    // }

    public void WriteDouble(double dvalue)
    {
        long value = BitConverter.DoubleToInt64Bits(dvalue);
        memoryStream.WriteByte((byte)value);
        memoryStream.WriteByte((byte)(value >> 8));
        memoryStream.WriteByte((byte)(value >> 16));
        memoryStream.WriteByte((byte)(value >> 24));
        memoryStream.WriteByte((byte)(value >> 32));
        memoryStream.WriteByte((byte)(value >> 40));
        memoryStream.WriteByte((byte)(value >> 48));
        memoryStream.WriteByte((byte)(value >> 56));
    }

    public byte[] GetSendableBytes()
    {
        return memoryStream.ToArray();
    }
}