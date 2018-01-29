using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool repeat = true;
                while (repeat == true)
                {
                    Console.WriteLine("Welcome to the Grand Circus Pig Latin Translator!");
                    Console.WriteLine("Please enter a line of text!");
                    string InputText = Console.ReadLine();

                    string[] WordArray = InputTextToArray(InputText); //breaks texts into array of words

                    foreach (string Word in WordArray)
                    {
                        if (CheckForNums(Word))//checks for word containing @ or nums and returns word as is
                        {
                            Console.WriteLine(Word);
                        }
                        else
                        {
                            string NewWord = DealWithPunctuation(Word, out string Punctuation);//checks for punctuation and creates substring for it
                            NewWord = CheckForVowels(NewWord); //Checks for vowel placement and performs operations
                            Console.Write(NewWord + Punctuation + " ");
                        }
                    }
                    repeat = RepeatProgram();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Whoops! Something went wrong! Please try again later!");
            }

        }
        public static bool RepeatProgram()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to try again? (y/n)");
            string Answer = Console.ReadLine().ToLower();
            if (Answer != "y")
            {
                bool repeat = false;
                Console.WriteLine("Goodbye!");
                return repeat;
            }
            else
            {
                bool repeat = true;
                Console.Clear();
                return repeat;
            }
        }
        public static string[] InputTextToArray(string InputText)//divides text by spaces into words
        {
            return InputText.Split(' ');
        }

        public static bool CheckForNums(string Word)
        {
            Regex Conditions = new Regex((@"@|\d"));

            if (Conditions.IsMatch(Word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string CheckForVowels(string Word)
        {
            char[] Vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            int VowelIndex = Word.IndexOfAny(Vowels);

            if (VowelIndex >= 0 )//if word does not start with a vowel or not contain a vowel
            {
                Word = DoesNotStartWithVowels(Word, VowelIndex);
                return Word;
            }
            else
            {
                Word = DoesStartWithVowels(Word);
                return Word;
            }
        }
        public static string DoesNotStartWithVowels(string Word, int VowelIndex)
        {
            Word = Word.Substring(VowelIndex, Word.Length - VowelIndex) + Word.Substring(0, VowelIndex) + "ay";
            return Word;

        }
        public static string DoesStartWithVowels(string Word)
        {
            return Word += "way";
        }
        public static string DealWithPunctuation(string Word, out string Punctuation)//breaks word into 2 substrings if punctuation is present
        {

            int LastChar = Word.Length - 1;

            if (Char.IsPunctuation(Word[LastChar]))
            {
                Punctuation = Word.Substring(LastChar, 1);
                string ReturnWord = Word.Substring(0, LastChar);
                
                return ReturnWord;
            }
            else
            {
                Punctuation = " ";
                return Word;
            }
        }
        
    }
}
