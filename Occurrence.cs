using System;

namespace TextAnalyzer
{
    public class Occurrence
    {
        public string Word { get; set; } = "";
        public int Count { get; set; } = 0;

        public Occurrence(string word, int count)
        {
            this.Word = word;
            this.Count = count;
        }
    }
}

