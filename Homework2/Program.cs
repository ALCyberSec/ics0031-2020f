using System;
using KeyExchange;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong mod = 0;
            ulong gen = 0;
            ulong p1 = 0;
            ulong p2 = 0;

            do
            {
                Console.Write("\nGen: ");
                
                try {
                    gen = Convert.ToUInt64(Console.ReadLine());
                } catch (System.Exception) {
                    Console.WriteLine("Gen must be >= 2");
                }
            } while (gen < 2);

            do
            {
                Console.Write("\nMod: ");

                try {
                    mod = Convert.ToUInt64(Console.ReadLine());
                } catch (System.Exception) {
                    Console.WriteLine("Mod must be prime");
                }
            } while (mod < 2);

            do
            {
                Console.Write("\nP1 Private Key: ");

                try {
                    p1 = Convert.ToUInt64(Console.ReadLine()); 
                } catch (System.Exception) { 
                    Console.WriteLine("Private key must be >= 2");
                }
            } while (p1 < 2);

            do
            {
                Console.Write("\nP2 Private Key: ");

                try {
                    p2 = Convert.ToUInt64(Console.ReadLine()); 
                } catch (System.Exception) { 
                    Console.WriteLine("Private key must be >= 2");
                }
            } while (p2 < 2);

            DHKeyExchange p1 = new DHKeyExchange(mod, gen, p1);
            DHKeyExchange p2 = new DHKeyExchange(mod, gen, p2, otherPart: p1);

            Console.WriteLine("Mod: {0}", p1.Mod);
            Console.WriteLine("Generator: {0}", p1.Gen);
            Console.WriteLine("Party 1 Public: {0}", p1.PublicKey);
            Console.WriteLine("Party 1 Private: {0}", p1.PrivateKey);
            Console.WriteLine("Party 1 Secret : {0}", p1.Secret);
            Console.WriteLine("Party 2 Public: {0}", p2.PublicKey);
            Console.WriteLine("Party 2 Private: {0}", p2.PrivateKey);
            Console.WriteLine("Party 2 Secret : {0}", p2.Secret);
        }
    }
}
