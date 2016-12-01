using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Net;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.PM;

namespace CLATest.Droid
{
	[Activity(Label = "Caja Los Andes", MainLauncher = true, Icon = "@mipmap/icon", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class ActivitySplash : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.splash_activity);
			VideoView mVideoView = FindViewById<VideoView>(Resource.Id.splash_video);

			string uripath = "android.resource://com.ewin.clatest/" + Resource.Raw.splash;
			Uri uri2 = Uri.Parse(uripath);
			mVideoView.SetVideoURI(uri2);
			mVideoView.RequestFocus();
			mVideoView.Start();


		}

		protected override void OnResume()
		{
			base.OnResume();

			Task startupwork = new Task(() =>
			{
				Task.Delay(1).Wait();

			});

			startupwork.ContinueWith(t =>
			{
				StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			}, TaskScheduler.FromCurrentSynchronizationContext());

			startupwork.Start();
		}
	}
}

