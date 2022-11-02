using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace TextAnalyzer
{
    /// <summary>
    /// TableDataSource object for occurrences data
    /// </summary>
    public class OccurrenceTableDataSource : NSTableViewDataSource
    {
        /// <summary>
        /// List of word occurrences used as bound datasource
        /// </summary>
        public List<Occurrence> Occurrences = new List<Occurrence>();

        /// <summary>
        /// Not Used; Constructor for object
        /// </summary>
        public OccurrenceTableDataSource()
        {
        }

        /// <summary>
        /// Gets the number of word occurrences in the data source
        /// </summary>
        /// <param name="tableView">TableView where the datasource is bound</param>
        /// <returns>integer of occurrences in datasource</returns>
        public override nint GetRowCount (NSTableView tableView)
        {
            return Occurrences.Count;
        }
    }
}

