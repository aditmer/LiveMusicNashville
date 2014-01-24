using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using LiveMusicCore.Core;

namespace LiveMusicNashville.iOS {
	public class RootTableSource : UITableViewSource {
		// ##
		// there is NO database or storage of Tasks in this example, just an in-memory List<>
		// refer to the other Tasky samples on github for an implementation using SQLite-NET
		// ##
		List<FeedItem> tableItems = new List<FeedItem> ();
		//Task[] tableItems;
		string cellIdentifier = "eventcell";

		public RootTableSource (IEnumerable<FeedItem> items)
		{
			tableItems = new List<FeedItem>(items); 
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].Title;

//			if (tableItems[indexPath.Row].Done) 
//				cell.Accessory = UITableViewCellAccessory.Checkmark;
//			else
//				cell.Accessory = UITableViewCellAccessory.None;

			return cell;
		}

//		public Task GetItem(int id) {
//			return tableItems[id];
//		}
	}
}