// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TextAnalyzer
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableColumn CountColumn { get; set; }

		[Outlet]
		AppKit.NSTableView OccurrencesTable { get; set; }

		[Outlet]
		AppKit.NSTableColumn WordColumn { get; set; }

		[Action ("ClickedButton:")]
		partial void ClickedButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (OccurrencesTable != null) {
				OccurrencesTable.Dispose ();
				OccurrencesTable = null;
			}

			if (WordColumn != null) {
				WordColumn.Dispose ();
				WordColumn = null;
			}

			if (CountColumn != null) {
				CountColumn.Dispose ();
				CountColumn = null;
			}
		}
	}
}
