using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace TextAnalyzer
{
    public class OccurrenceTableDataSource : NSTableViewDataSource
    {
        public List<Occurrence> Occurrences = new List<Occurrence>();

        public OccurrenceTableDataSource()
        {
        }

        public override nint GetRowCount (NSTableView tableView)
        {
            return Occurrences.Count;
        }
    }
}

