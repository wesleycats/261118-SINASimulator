using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encryption
{
    // Secret keyword.
    private static readonly string PASSWORD = "SECRET_KEYWORD";
    // 16-byte private password.
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("0123456789012345");

    private static readonly byte[] key = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(PASSWORD));
    private static readonly RijndaelManaged cipher = new RijndaelManaged();

    public static byte[] Encrypt(byte[] bytes)
    {
        return cipher.CreateEncryptor(key, IV).TransformFinalBlock(bytes, 0, bytes.Length);
    }

    public static byte[] Decrypt(byte[] bytes)
    {
        return cipher.CreateDecryptor(key, IV).TransformFinalBlock(bytes, 0, bytes.Length);
    }
}
