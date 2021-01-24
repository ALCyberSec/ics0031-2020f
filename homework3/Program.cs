using System;
using HW3;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RSA");

            var userInput = "";
            do
            {
                Console.WriteLine("RSA");
                Console.WriteLine("a) RSA ENCRYPTION");
                Console.WriteLine("b) RSA BRUTE FORCE");
                Console.WriteLine("e) Exit");
                Console.Write(">");

                userInput = Console.ReadLine()?.ToLower();

                switch (userInput)
                {
                    case "e":
                        RSALogic.Encrypt();
                        break;
                    case "b":
                        RSALogic.BruteForce();
                        break;
                    case "e":
                        break;
                    default:
                        Console.WriteLine($"Please select a valid option");
                        break;
                }
            } while (userInput != "e");
        }
    }
}
