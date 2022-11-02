using AppKit;
using Foundation;

namespace TextAnalyzer
{
    /// <summary>
    ///  The AppDelegate handles system events
    /// </summary>
    [Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
        /// <summary>
        /// Not Used: Constructor function
        /// </summary>
		public AppDelegate ()
		{
		}

        /// <summary>
        ///  Run additional code after the application has launched
        /// </summary>
        public override void DidFinishLaunching (NSNotification notification)
		{
			// Insert code here to initialize your application
		}

        /// <summary>
        ///  Run additional cleanup before the application is terminated
        /// </summary>
        public override void WillTerminate (NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}

