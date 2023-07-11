using MultiDictionary.IO;
using MultiDictionary.Stats;

namespace MultiDictionary.Dict
{
    public class Dictionary
    {
        public static List<Dictionary> MultiDictionary { get; } = new();
        public List<string> Words { get; set; }
        public string Language { get; set; }

        public Dictionary(string language)
        {
            Words = new List<string>();
            Language = language;
        }

        public static bool CheckForLanguage(string language)
        {
            return MultiDictionary.Any(dictionary => dictionary.Language == language);
        }

        public static void AddNewWords(string language, IEnumerable<string> words)
        {
            MultiDictionary.First(dictionary => dictionary.Language == language).Words.AddRange(words);
            JsonParser.SerializeToJson(language);
        }

        public static void AddNewLanguage(string language)
        {
            MultiDictionary.Add(new Dictionary(language));
            JsonParser.SerializeToJson(language);
        }

        public static bool CheckForWord(string word, out string languages)
        {
            languages = null;
            List<Dictionary> selectedDictionaries = MultiDictionary.Where(dictionary => dictionary.Words.Contains(word)).ToList();
            if (selectedDictionaries.Any())
            {
                selectedDictionaries.ForEach(dictionary =>
                {
                    if (Statistics.WordReferences.TryGetValue(word, out SortedSet<string> reference)) reference.Add(dictionary.Language);
                    else Statistics.WordReferences[word] = new SortedSet<string> { dictionary.Language };
                });
                languages = string.Join(", ", selectedDictionaries.Select(dictionary => dictionary.Language));
            }
            else
            {
                if (Statistics.WordReferences.TryGetValue(word, out SortedSet<string> reference)) reference.Add("Doesn't exist");
                else Statistics.WordReferences[word] = new SortedSet<string> { "Doesn't exist" };
            }
            Statistics.TotalReferences++;
            return languages != null;
        }
    }
}