using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace LiveMusicNashville.Droid
{
	[Activity (Label = "Live Music Events")]
	public class EventDetails : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Detail);

			WebView webDetails = FindViewById<WebView> (Resource.Id.webView1);

			webDetails.LoadDataWithBaseURL("",Intent.GetStringExtra ("Description"),"text/html", "UTF-8", "");
		}
	}
}

