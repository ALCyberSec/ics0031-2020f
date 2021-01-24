using System;
using System.Collections.Generic;
using System.Text;


namespace Cipher
{
    public class CipherJob
    {
        private static byte[] ProcessByteCipher(byte[] bytes, IReadOnlyList<byte> key, string actionId)
        {
            int keyLength = key.Count;
            int keyIndex2 = 0;
            int i = 0;
            while (i < bytes.Length)
            {
                keyIndex2 %= keyLength;
                int num = i;
                byte b;
                if (!(actionId == "encrypt"))
                {
                    if (!(actionId == "decrypt"))
                    {
                        throw new ArgumentException("Invalid cipher argument.");
                    }
                    b = (byte)((bytes[i] - key[keyIndex2] + 255 + 1) % 256);
                }
                else
                {
                    b = (byte)((bytes[i] + key[keyIndex2]) % 256);
                }
                bytes[num] = b;
                i++;
                keyIndex2++;
            }
            return bytes;
        }

        public static void Encipher(string message, string key)
        {
            byte[] byteStream = ProcessByteCipher(Encoding.UTF8.GetBytes(message), Encoding.UTF8.GetBytes(key), "encrypt");
            Console.WriteLine("Your plaintext is: " + message);
            Console.WriteLine("Your ciphertext is: " + Convert.ToBase64String(byteStream));
        }

        public static void Decipher(string cipher, string key)
        {
            byte[] byteStream = ProcessByteCipher(Convert.FromBase64String(cipher), Encoding.UTF8.GetBytes(key), "decrypt");
            Console.WriteLine("The message is:");
            Console.WriteLine("- base64: " + Convert.ToBase64String(byteStream));
            Console.WriteLine("- plain: " + Encoding.UTF8.GetString(byteStream));
        }
    }
}