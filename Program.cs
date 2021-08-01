using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ConsoleApp8
{
    class Program
    {
        private static readonly byte[] SecretKey = new byte[16];
        static void Main(string[] args)
        {
            string[] arrayNumber; 
            int count; 
            string s;
            string[] AS2; 

            count = 0; 
            arrayNumber = new string[count]; 

            do
            {
                s = Console.ReadLine();
                if (s != "")
                {
                    count++;
                    AS2 = new string[count];
                    for (int i = 0; i < AS2.Length - 1; i++)
                        AS2[i] = arrayNumber[i];
                    AS2[count - 1] = s;
                    arrayNumber = AS2;
                }
            } while (s != "");
            string[] elements = new string[count];
            
            for (int i = 0; i < arrayNumber.Length; i++)
            {
                elements[i] = arrayNumber[i];
            }

            KeyGeneratorHelper.GenerateSecretKey(SecretKey);
            var hmacSha = KeyGeneratorHelper.GenerateHmacSha(SecretKey);

            Random random = new Random();
            int arrayPosition = random.Next(0, elements.Length);
            string pcMove = elements[arrayPosition];
            var hash = hmacSha.ComputeHash(Encoding.UTF8.GetBytes(elements[arrayPosition]));
            Console.WriteLine("\nHMAC : " + BitConverter.ToString(hash, 0));

            Console.WriteLine("\nAvailable moves: ");
            for (int i = 0; i < elements.Length; i++)
                Console.WriteLine("{0} - {1}", i + 1, elements[i]);
            Console.WriteLine("0 - Exit");

                Console.Write("\nEnter your move: ");
            int userMove = int.Parse(Console.ReadLine());

            Console.WriteLine("Your move: {0}", elements[userMove - 1]);

            Console.WriteLine("\nComputer move: {0}", pcMove);

            for (int i = 0; i < elements.Length / 2; i++)
            {
                if (elements[userMove] == pcMove)
                {
                    Console.WriteLine("You lose!");
                }
                else
                {
                    Console.WriteLine("You win!");
                    break;
                }
                userMove++;
            }

            Console.WriteLine("Key : " + (BitConverter.ToString(SecretKey, 0)));
                
        }
    }
}
