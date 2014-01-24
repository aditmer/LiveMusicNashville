using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net.Wifi;

using System.Xml;
using LiveMusicCore.Core;


namespace LiveMusicNashville.Droid
{
//	public class FeedItem
//	{
//		public string Title { get; set; }
//
//		public string Description { get; set; }
//
//		public DateTime Date { get; set; }
//	}

	[Activity (Label = "Live Music Events", MainLauncher = true)]
	public class MainActivity : Activity
	{
		MainViewModel viewModel;

		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			viewModel = new MainViewModel ();

			RequestWindowFeature (WindowFeatures.IndeterminateProgress);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			ListView listView = FindViewById<ListView> (Resource.Id.listView1);
			listView.FastScrollEnabled = true;
			listView.FastScrollAlwaysVisible = true;
//
			SetProgressBarIndeterminateVisibility (true);
			await viewModel.GetEventsAsync ();
			SetProgressBarIndeterminateVisibility (false);
//
//			XmlDocument doc = new XmlDocument ();
//
//			doc.Load ("http://www.nowplayingnashville.com/feeds/event/rss/3/");
//
//			foreach (XmlNode node in doc.SelectNodes("//item")) {
//				feedItems.Add (new FeedItem () {
//					Title = node.SelectSingleNode ("title").InnerText,
//					Description = node.SelectSingleNode ("description").InnerText
//				});
//			}

			listView.Adapter = new FeedAdapter (this, viewModel.FeedItems);
			listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var eventDetails = new Intent (this, typeof (EventDetails));
				eventDetails.PutExtra("Description", viewModel.FeedItems[e.Position].Description);

				StartActivity(eventDetails);
			};
		}


	}

	public class FeedAdapter : BaseAdapter<FeedItem>
	{
		List<FeedItem> items;
		Activity context;

		public FeedAdapter(Activity context, IEnumerable<FeedItem> items) : base() 
		{
			this.context = context;
			this.items = new List<FeedItem>(items);
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override FeedItem this[int position]
		{  
			get { return items[position]; }
		}

		public override int Count {
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Title;
			return view;
		}
	}
}