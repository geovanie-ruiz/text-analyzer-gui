using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace TextAnalyzer
{
    public class OccurrenceTableDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "OccurCell";

        private OccurrenceTableDataSource DataSource;

        public OccurrenceTableDelegate(OccurrenceTableDataSource datasource)
        {
            this.DataSource = datasource;
        }

        public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            switch (tableColumn.Title)
            {
                case "Word":
                    view.StringValue = DataSource.Occurrences[(int)row].Word;
                    break;
                case "Count":
                    view.StringValue = DataSource.Occurrences[(int)row].Count.ToString();
                    break;
            }

            return view;
        }
    }
}

