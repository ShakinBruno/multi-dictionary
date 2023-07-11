using System.Text.Json;
using MultiDictionary.Dict;

namespace MultiDictionary.IO
{
    public static class JsonParser
    {
        private const string dictionariesDirectory = "MultiDictionary";
        private static readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = true
        };

        public static void DeserializeFromJson()
        {
            if (!Directory.Exists(dictionariesDirectory)) Directory.CreateDirectory(dictionariesDirectory);
            string[] files = Directory.GetFiles(dictionariesDirectory, "*.json", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                string jsonString = File.ReadAllText(file);
                var dictionary = JsonSerializer.Deserialize<Dictionary>(jsonString, jsonOptions);
                if (dictionary != null) Dictionary.MultiDictionary.Add(dictionary);
            }
        }

        public static void SerializeToJson(string language)
        {
            string filePath = Path.Combine(dictionariesDirectory, $"{language}.json");
            Dictionary selectedDictionary = Dictionary.MultiDictionary.First(dictionary => dictionary.Language == language);
            selectedDictionary.Words.Sort();
            string jsonString = JsonSerializer.Serialize(selectedDictionary, jsonOptions);
            File.WriteAllText(filePath, jsonString);
        }
    }
}