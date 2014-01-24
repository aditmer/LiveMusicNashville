using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;


namespace LiveMusicCore.Core
{
	public class MainViewModel
	{
		public ObservableCollection<FeedItem> FeedItems{ get; set; }
		public MainViewModel()
		{
			FeedItems = new ObservableCollection<FeedItem> ();
		}

		public void GetEvents ()
		{

			XmlDocument doc = new XmlDocument ();

			doc.Load ("http://www.nowplayingnashville.com/feeds/event/rss/3/");

			foreach (XmlNode node in doc.SelectNodes("//item")) {
				FeedItems.Add (new FeedItem () {
					Title = node.SelectSingleNode ("title").InnerText,
					Description = node.SelectSingleNode ("description").InnerText
				});
			}
		}

		public async Task GetEventsAsync()
		{
			var httpClient = new HttpClient ();
			var xml = await httpClient.GetStringAsync ("http://www.nowplayingnashville.com/feeds/event/rss/3/");
			var feedItems = await ParseFeedAsync (xml);
			foreach (var feedItem in feedItems)
				FeedItems.Add (feedItem);
		}

		public async Task<List<FeedItem>> ParseFeedAsync(string feed)
		{
			return await Task.Factory.StartNew (() => {
				List<FeedItem> feedItems = new List<FeedItem> ();

				var doc = new XmlDocument ();

				doc.LoadXml (feed);

				foreach (XmlNode node in doc.SelectNodes("//item")) {
					feedItems.Add (new FeedItem () {
						Title = node.SelectSingleNode ("title").InnerText,
						Description = node.SelectSingleNode ("description").InnerText
					});
				}

				return feedItems;
			});
		}


	}
}

