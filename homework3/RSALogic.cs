using System;

namespace HW3
{

    public class RSALogic
    {

        public static void Encrypt()
        {
            ulong p;
            ulong q;


            do
            {
                Console.Write("\nPrime p: ");
                p = UlongValidate(Console.ReadLine());
            } while (p <= 1);

            do
            {
                Console.Write("\nPrime q: ");
                q = UlongValidate(Console.ReadLine());
            } while (q <= 1);

            var n = p * q;
            var m = (p - 1) * (q - 1);
            ulong e;
            ulong d = 0;

            Console.WriteLine($"n is {n}");
            Console.WriteLine($"m is {m}");


            for (e = 2; e < ulong.MaxValue; e++)
            {
                if (Gcd(e, m) == 1)
                {
                    break;
                }
            }


            for (ulong k = 2; k < ulong.MaxValue; k++)
            {
                if ((1 + k * m) % e == 0)
                {
                    d = (1 + k * m) / e;
                    break;
                }
            }

            Console.WriteLine($"Public key  {n} {e}");
            Console.WriteLine($"Private key {n} {d}");

            ulong message;

            do
            {
                var messageStr = GetInput("Message: ");

                if (!ulong.TryParse(messageStr, out message))
                {
                    Console.WriteLine("string not ulong");
                    continue;
                }

                if (n < message)
                {
                    Console.WriteLine("message string value less than n (p * q)");
                    continue;
                }

                break;
            } while (true);

            var cipher = ModCalculator(message, e, n);
            Console.WriteLine($"Cipher: {cipher}");

            var plainMessage = ModCalculator(cipher, d, n);
            Console.WriteLine($"Plain Message: {plainMessage}");
        }

        public static void BruteForce()
        {
            ulong pubE;
            ulong pubN;
            ulong cipher;
            ulong p = 0;
            ulong q = 0;
            ulong m;

            do
            {
                var primeOneString = GetInput("Public key n: ");

                if (!ulong.TryParse(primeOneString, out pubN))
                {
                    Console.WriteLine("not valid");
                    continue;
                }

                var primeTwoString = GetInput("Public key e: ");
                if (!ulong.TryParse(primeTwoString, out pubE))
                {
                    Console.WriteLine("not valid");
                    continue;
                }

                if (pubE == 1 || pubN == 1)
                {
                    Console.WriteLine("e or n should be more than 1");
                    continue;
                }

                var cipherString = GetInput("Cipher: ");

                if (!ulong.TryParse(cipherString , out cipher))
                {
                    Console.WriteLine("not valid");
                    continue;
                }

                break;
            } while (true);

            for (ulong i = 3; i < ulong.MaxValue; i+=2)
            {
                if ((pubN % i) == 0)
                {
                    p = i;
                    q = pubN / i;
                    break;
                }
            }

            m = (q - 1) * (p - 1);

            ulong d = 0;
            for (ulong k = 2; k < ulong.MaxValue; k++)
            {
                if ((1 + k * m) % pubE == 0)
                {
                    d = (1 + k * m) / pubE;
                    break;
                }
            }

            var plainMessage = ModCalculator(cipher, d, pubN);
            Console.WriteLine($"plainText: {plainMessage}");
        }

        static ulong Power(ulong @base, ulong exponent)
        {
            ulong result = 1;

            for (ulong i=0; i<exponent; i++)
            {
                result *= @base;
            }

            return result;
        }

        static bool IsPrime(ulong value)
        {
            for (ulong i = 2; i < Math.Floor(Math.Sqrt(value)); i++){
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static ulong UlongValidate(string a)
        {
            ulong number;

            if (UInt64.TryParse(a, out number))
            {
                if (IsPrime(number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Number is not a prime");
                    return 0;
                }
            }

            Console.WriteLine("Input is Invalid");

            return 0;
        }

        private static ulong Gcd(ulong a, ulong b)
        {
            return a == 0 ? b : Gcd(b % a, a);
        }

        private static string GetInput(string message) {
            Console.WriteLine(message);
            Console.Write("- ");

            return Console.ReadLine()?.Trim();
        }

        static ulong ModCalculator(ulong g, ulong priv, ulong p)
        {
            if (p == 1) return 0;

            ulong c = 1;
            
            for (ulong i = 0; i < priv; i++)
            {
                c = (c * g) % p;
            }

            return c;
        }
    }
}
