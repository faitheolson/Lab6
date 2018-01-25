using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            char[] chars = { 'a', 'e', 'i', 'o', 'u',
                       'A', 'E', 'I', 'O', 'U'};

            while (repeat == true)
            {
                Console.WriteLine("Please enter a word:");
                string Input = Console.ReadLine();
                //Input = Input.ToUpper();

                int VowelValidation = Input.IndexOfAny(chars);

                if (VowelValidation == 0)
                {
                    Console.WriteLine("Your word starts with a vowel!");
                    Console.WriteLine($"{Input}way");
                }
                else
                {
                    Console.WriteLine("Your word DOES NOT start with a vowel!");
                    string BeforeVowels = (Input.Remove(VowelValidation));
                    Console.WriteLine(BeforeVowels);
                    Console.WriteLine(Input);
                    Console.WriteLine($"{(Input.Substring(VowelValidation, Input.Length - VowelValidation))}{BeforeVowels}ay");
                }

                Console.WriteLine("Would you like to try another word?");
                string again = Console.ReadLine();

                if (again != "y" && again != "Y")
                {
                    repeat = false;
                    Console.Clear();
                    Console.WriteLine("Oodbyay!");
                }
                else
                {
                    Console.Clear();
                }

                
            }
            
        }
    }
}
