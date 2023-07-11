using MultiDictionary.Dict;
using MultiDictionary.IO;

namespace MultiDictionary.App
{
    public static class App
    {
        private enum ActionType
        {
            None,
            AddWord,
            AddLanguage,
            CheckWord,
            GenerateFile,
            Exit
        }
        
        private static void Main()
        {
            JsonParser.DeserializeFromJson();
            while (true)
            {
                Console.WriteLine("1. Add a new word in an existing language.\n" +
                                  "2. Add a new language.\n" +
                                  "3. Check the origin of the word.\n" +
                                  "4. Generate statistics file.\n" +
                                  "5. Exit the program.\n");
                Console.Write("What do you want to do?: ");
                try
                {
                    var action = (ActionType)int.Parse(Console.ReadLine() ?? string.Empty);
                    if (action == ActionType.Exit) Environment.Exit(0);
                    switch (action)
                    {
                        case ActionType.AddWord:
                            AddWord();
                            break;
                        case ActionType.AddLanguage:
                            AddLanguage();
                            break;
                        case ActionType.CheckWord:
                            CheckWord();
                            break;
                        case ActionType.GenerateFile:
                            PDF.CreateStatsFile();
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.Write("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void AddWord()
        {
            Console.Write("Dictionary of which language should be updated?: ");
            string language = Console.ReadLine() ?? string.Empty;
            if (Dictionary.CheckForLanguage(language))
            {
                Console.Write("Specify how many words you want to add: ");
                int amount = int.Parse(Console.ReadLine() ?? string.Empty);
                var words = new string[amount];
                for (var i = 0; i < amount; i++)
                {
                    Console.Write("Enter a word: ");
                    words[i] = Console.ReadLine() ?? string.Empty;
                }
                Dictionary.AddNewWords(language, words);
            }
            else Console.WriteLine($"There is no such dictionary as {language}");
        }

        private static void AddLanguage()
        {
            Console.Write("Enter the new language: ");
            string newLanguage = Console.ReadLine() ?? string.Empty;
            Dictionary.AddNewLanguage(newLanguage);
        }

        private static void CheckWord()
        {
            Console.Write("Enter the word you want to search for: ");
            string word = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(Dictionary.CheckForWord(word, out string languages) ? languages : "The given word doesn't exist in any dictionary.");
        }
    }
}