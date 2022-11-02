using System;

namespace TextAnalyzer
{
    /// <summary>
    ///  Holds the word and occurrences
    /// </summary>
    public class Occurrence
    {
        /// <summary>
        ///  Occurrence word property
        /// </summary>
        public string Word { get; set; } = "";

        /// <summary>
        ///  Occurence count property
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        ///  Constructor function
        /// </summary>
        /// <param name="word">The word whose occurrences is being counted</param>
        /// <param name="count">The number of times a word appears</param>
        public Occurrence(string word, int count)
        {
            this.Word = word;
            this.Count = count;
        }
    }
}

