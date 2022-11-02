using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace TextAnalyzer
{
    /// <summary>
    /// A table view delegate provides views for table rows and columns, and
    /// supports functionality such as column reordering and resizing and row
    /// selection.
    /// </summary>
    public class OccurrenceTableDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "OccurCell";

        private OccurrenceTableDataSource DataSource;

        /// <summary>
        /// Set the data source for the Occurrences table
        /// </summary>
        /// <param name="datasource">Data to be viewed in the table</param>
        public OccurrenceTableDelegate(OccurrenceTableDataSource datasource)
        {
            this.DataSource = datasource;
        }

        /// <summary>
        /// Build a view for each occurrence item
        /// </summary>
        /// <param name="tableView">Table data is to be bound to</param>
        /// <param name="tableColumn">Column for data</param>
        /// <param name="row">Row for data</param>
        /// <returns>NSView object for data</returns>
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

