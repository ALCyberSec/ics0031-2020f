using System;
using System.Text;
using Cipher;
using UserInput;


/*Name: ALI IZADY SADR | 194444IVSB 
Course: ICS0031*/

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ICS0031-2020F | ALI IZADY SADR | HOMEWORK_1");
            Console.WriteLine("Choose your Cryptography please...");
            Console.WriteLine("for Cesar cipher (1) for Vigenere Cipher (2) and to end the program (X)");

            

            var userInput = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("1) Cesar cipher Crypto");
                Console.WriteLine("2) Vigenere cipher Crypto");
                Console.WriteLine("X) End");
                Console.Write(">>");
                
                
                userInput = Console.ReadLine()?.ToLower();

                switch (userInput)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("1) Encrypt Caesars");
                            Console.WriteLine("2) Decrypt Caesars");
                            Console.WriteLine("x) End");
                            userInput = Console.ReadLine()?.ToLower();
                            switch (userInput)
                            {
                                case "1":

                                    Cesar();
                                    break;
                                case "2":
                                    Cesar(isEncrypt:false);
                                    break;

                                case "x":
                                    Console.WriteLine("Exiting...");
                                    break;
                                default:
                                    Console.WriteLine($"No option for '{userInput}'!");
                                    break;

                            }
                        } while (userInput != "x");

                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("1) Encrypt Vigeneres");
                            Console.WriteLine("2) Decrypt Vigeneres");
                            Console.WriteLine("x) End");
                            userInput = Console.ReadLine()?.ToLower();
                            switch (userInput)
                            {
                                case "1":
                                    

                                    Vigenere();
                                    break;
                                case "2":
                                    Vigenere(isEncrypt:false);
                                    break;

                                case "x":
                                    Console.WriteLine("Exiting...");
                                    break;
                                default:
                                    Console.WriteLine($"No option for '{userInput}'!");
                                    break;

                            }
                        } while (userInput != "x");
                        break;
                    case "x":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine($"No option for '{userInput}'!");
                        break;
                }
            } while (userInput != "x");

        }

        static void Cesar(bool isEncrypt = true)
        {
            Console.WriteLine("Cesar Cipher");

            // byte per character
            // 0-255
            // 0-127 - latin
            // 128-255 - change what you want
            // ABCD - A 189, B - 195, C 196, D 202
            // unicode 
            // AÄÖÜLA❌
            
            var userInput = "";
            var key = 0;
            do
            {
                Console.Write("Shift amount please (or X to cancel):");
                userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput != "x")
                {
                    if (int.TryParse(userInput, out var userValue))
                    {
                        key = userValue % 255;
                        if (key == 0)
                        {
                            Console.WriteLine("not a cipher option, nothing will change!");
                        }
                        else
                        {
                            Console.WriteLine($"Cesar key is: {key}");
                        }
                    }
                }

            } while (key == 0 && userInput != "x");

            if (userInput == "x") return;

            if (!isEncrypt)
            {
                Console.Write("Cipher_Text please:");
                var plainText = Console.ReadLine();
                if (plainText != null)
                {
                    if (!Input.ValidateBase64(plainText))
                    {
                        Console.WriteLine("Cipher is ONLY base64");
                    }
                    else
                    {
                        CipherJob.Decipher(plainText, $"{(char)key}");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Cipher_Text is Invalid!");
                }
            }
            else
            {
                Console.Write("Enter The Cipher_Text:");
                var plainText = Console.ReadLine();
                if (plainText != null)
                {
                    CipherJob.Encipher(plainText, $"{(char)key}");
                }
                else
                {
                    Console.WriteLine("Plain_text is Invalid!");
                }
            }
            
        }

        static void Vigenere(bool isEncrypt = true)
        {
            Console.WriteLine("Vigenere");
            

            var userInput = "";
            var key = "";
            
            
            do
            {
                Console.Write("Enter the Key (or X to cancel):");
                userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput != "x")
                {
                    if (!String.IsNullOrEmpty(userInput))
                    {
                        key = userInput;
                        
                    }

                    else
                    {
                        Console.WriteLine("Enter a Valid Key");
                    }
                }

            } while (String.IsNullOrEmpty(userInput) && userInput != "x");
            
            if (userInput == "x") return;

            if (!isEncrypt)
            {
                Console.Write(" You Cipher_Text Please:");
                var plainText = Console.ReadLine();
                if (plainText != null)
                {
                    if (!Input.ValidateBase64(plainText))
                    {
                        Console.WriteLine("Cipher is ONLY base64");
                    }
                    else
                    {
                        CipherJob.Decipher(plainText, key);
                    }
                    
                }
                else
                {
                    Console.WriteLine("CipherText is Invalid!");
                }
            }
            else
            {
                Console.Write("Your Plain_Text please:");
                var plainText = Console.ReadLine();
                if (plainText != null)
                {
                    CipherJob.Encipher(plainText, key);
                }
                else
                {
                    Console.WriteLine("Plaintext is Invalid!");
                }
            }

        }
        
    }
}
