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

                    string[] WordArray = InputTextToArray(InputText);

                    foreach (string Word in WordArray)
                    {
                        if (CheckForNums(Word))//checks for word containing @ or nums and returns word as is
                        {
                            Console.WriteLine(Word);
                        }
                        else
                        {
                            string NewWord = CheckForVowels(Word);
                            Console.Write(NewWord + " ");
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
        public static string[] InputTextToArray(string InputText)
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

            if (VowelIndex > 0 || VowelIndex < 0)//if word does not start with a vowel or not contain a vowel
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
        //***Tried to find a method to move punctuation to the end but didn't get finished
        //public static string MovePunctuation(string Word)
        //{
        //    //char[] Punctuation = { '!', ',', '?', '.',':',';'};
        //    //int LastChar= Word.LastIndexOfAny(Punctuation);
        //    if (Word.EndsWith(@"?|!"))
        //    {
        //        //Punct = NewWord.Substring(NewWord.Length,NewWord.Length);
        //        return Word.Substring(0,Word.Length-1);
        //    }
        //    else
        //    {
        //        //Punct = null;
        //        return Word + "not working!";

    }
}
