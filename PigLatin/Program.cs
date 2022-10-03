namespace PigLatin
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, in this program, we will be translating words/phrases from English into Pig Latin!");
            bool goOn = true;
            while (goOn == true)
            {
                Console.WriteLine("Please input what you want translated.");
                string data = Console.ReadLine().ToLower();

                if(String.IsNullOrEmpty(data))
                {
                    Console.WriteLine("Please input a word/phrase to translate.");
                    continue;
                }
                else
                {
                    string pigLatin = Translate(data);
                    Console.WriteLine(pigLatin);
                }

                goOn = AskToContinue();
            }
        }
        public static string Translate(string data)
        {
            string vowels = "aeiou";
            vowels = vowels.ToLower();
            string sentence = "";

            foreach (string word in data.Split(' '))
            {
                
                string startOfWord = word.Substring(0,1);
                string remainder = word.Substring(1, word.Length-1);
                int letter = vowels.IndexOf(startOfWord);
                string finalword;

                if(letter == -1)
                {
                    finalword = (remainder + startOfWord + "ay");
                }
                else
                {
                    finalword = (word + "way");
                }
                sentence = sentence + finalword + " " ;
            }
            //Data could be an empty string - declare an empty string before the foreach statement
            return sentence;
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to try more translations? Y/N");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if(input == "n")
            {
                Console.WriteLine("Thank you for using my translator!");
                return false;
            }
            else
            {
                Console.WriteLine("Input invalid. Please try again.");
                return AskToContinue();
            }
        }
    }
}