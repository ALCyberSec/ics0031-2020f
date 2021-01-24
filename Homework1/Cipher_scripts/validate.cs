using System;
using System.Text.RegularExpressions;

namespace UserInput

{
    public class Input
    {
        public static string GetKey()
        {
            Console.Write("Please enter your key: ");
            return Console.ReadLine();
        }
        
        public static bool ValidateBase64(string input)
        {
            try

            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(input);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (input.Replace(" ","").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }
    }
}