// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace LiveMusicNashville.iOS
{
	[Register ("MasterViewController")]
	partial class MasterViewController
	{
		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView tableView1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableView1 != null) {
				tableView1.Dispose ();
				tableView1 = null;
			}
		}
	}
}
