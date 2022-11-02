using System;
using System.IO;
using System.Xml;
using System.Text;
using HtmlAgilityPack;

using AppKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer
{
    /// <summary>
    /// Logic for the UI
    /// </summary>
	public partial class ViewController : NSViewController
	{
        /// <summary>
        /// Flag variable to indicate reader was ran; prevents the button from
        /// being spammed but in the future would be set to false if the data
        /// source somehow changed
        /// </summary>
        public bool wasRan = false;

        /// <summary>
        /// Parse the poem segment of a larger document; remove line breaks
        /// </summary>
        /// <param name="poem">poem-specific text</param>
        /// <returns>HtmlNode poem text after parsing</returns>
        private HtmlNode parsePoem(HtmlNode poem)
        {
            /*
                Manipulate HTML to remove br characters since removing it
                from the list directly is not a straightforward option
            */
            string poemHtml = poem.OuterHtml;

            // Convert <br> and newline character to delimiter
            poemHtml = poemHtml.Replace("<br>", "|").Replace("\n", "|");

            var poemDoc = new HtmlDocument();
            poemDoc.LoadHtml(poemHtml);

            return poemDoc.DocumentNode.SelectSingleNode("//div");
        }

        /// <summary>
        /// Not used: A constructor used when creating managed representations
        /// of unmanaged objects
        /// </summary>
        /// <param name="handle">Reference to unmanaged object</param>
        public ViewController (IntPtr handle) : base (handle)
		{
		}

        /// <summary>
        /// Run setup after a view has loaded
        /// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any additional setup after loading the view.
		}

        /// <summary>
        /// Creates a reference to a bound object
        /// </summary>
		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

        /// <summary>
        /// Functionality to run after the button is clicked
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        partial void ClickedButton(NSObject sender)
        {
            if (wasRan) return;

            string path = Path.Combine(NSBundle.MainBundle.PathForResource("the_file", "html"));
            var doc = new HtmlDocument();
            doc.Load(path);

            HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
            HtmlNode title = body.SelectSingleNode("//h1");
            HtmlNode byLine = body.SelectSingleNode("//h2");
            HtmlNode poem = parsePoem(body.SelectSingleNode("//div[@class='chapter']"));

            string fullPoem = $"{title.InnerText} {byLine.InnerText} {poem.InnerText}";

            // Convert space between words to delimiter
            fullPoem = fullPoem.StripPunctuation().Replace(" ", "|");

            // Split on delimiter and remove any empty values
            string[] words = fullPoem.Split("|").Where(s => !string.IsNullOrEmpty(s)).ToArray();

            // Create a hashmap to track instances of words
            Dictionary<string, int> wordsMap = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordKey = word.ToLower();

                if (wordsMap.ContainsKey(wordKey))
                {
                    wordsMap[wordKey] += 1;
                }
                else
                {
                    wordsMap.Add(wordKey, 1);
                }
            }

            // Get the top 20 results
            var topResults = (from word in wordsMap orderby word.Value descending select word).Take(20);

            // Build table
            var DataSource = new OccurrenceTableDataSource();
            foreach (var kv in topResults)
            {
                Console.WriteLine(kv.Key + ", " + kv.Value);
                DataSource.Occurrences.Add(new Occurrence(kv.Key, kv.Value));
            }

            OccurrencesTable.DataSource = DataSource;
            OccurrencesTable.Delegate = new OccurrenceTableDelegate(DataSource);

            wasRan = true;
        }
    }
}
