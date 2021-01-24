using System;
using System.Text;
using Crypto;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarDemo();
        }

        static void CesarDemo()
        {
            Console.WriteLine("Cesar Demo");

            var userInput = "";
            var key = 0;
            
            do
            {
                Console.Write("Your shift amount (or c to cancel):");
                userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput != "c")
                {
                    if (int.TryParse(userInput, out var userValue))
                    {
                        key = userValue % 255;
                        if (key == 0)
                        {
                            Console.WriteLine("multiples of 255 is invalid cipher");
                        }
                        else
                        {
                            Console.WriteLine($"Cesar key is: {key}");
                        }
                    }
                }
            } while (key == 0 && userInput != "c");

            if (userInput == "c") return;
            
            Console.Write("Your plaintext:");
            
            var plainText = Console.ReadLine();
            
            if (plainText != null)
            {
                Console.WriteLine($"length : {plainText.Length}");

                ShowEncoding(plainText, Encoding.Default);

                var encryptedBytes = Cesar.Encrypt(plainText, (byte) key, Encoding.Default);

                Console.Write("Encrypted bytes : ");
                
                foreach (var encryptedByte in encryptedBytes)
                {
                    Console.Write(encryptedByte + " ");
                }

                Console.WriteLine("base64 : " + System.Convert.ToBase64String(encryptedBytes));
            }
            else
            {
                Console.WriteLine("Plain text null");
            }
        }

        static void ShowEncoding(string text, Encoding encoding)
        {
            Console.WriteLine(encoding.EncodingName);

            Console.Write("Preamble ");
            foreach (var preambleByte in encoding.Preamble)
            {
                Console.Write(preambleByte + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{text[i]} ");
                foreach (var byteValue in encoding.GetBytes(text.Substring(i, 1)))
                {
                    Console.Write(byteValue + " ");
                }
            }

            Console.WriteLine();
        }
    }
}