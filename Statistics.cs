namespace MultiDictionary.Stats
{
    public static class Statistics
    {
        public static Dictionary<string, SortedSet<string>> WordReferences { get; } = new();
        public static int TotalReferences { get; set; }
    }
}