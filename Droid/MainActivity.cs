
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace CLATest.Droid
{
	[Activity(Label = "CLATest", Theme = "@style/AppTheme",ScreenOrientation = ScreenOrientation.Portrait ,WindowSoftInputMode = SoftInput.AdjustPan)]
	public class MainActivity : AppCompatActivity
	{
		
		//sLinearLayout linear;
		TabLayout tabLayout;
		ViewPager mPager;
		EditText rut;
		EditText password;
		LoginMenuFragmnet loginMenuFragment;
		PageCustomAdapter pageCustomAdapter;
		LinearLayout linear;
		Animation anim_menu;





		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

				Window.SetStatusBarColor(Resources.GetColor(Resource.Color.colorPrimaryDark));


			}
			linear = (LinearLayout)FindViewById(Resource.Id.linear_form);
			linear.SetBackgroundColor(Android.Graphics.Color.Argb(180, 235, 235, 235));
			anim_menu = AnimationUtils.LoadAnimation(this, Resource.Animation.mov_login);
			mPager = FindViewById<ViewPager>(Resource.Id.pager);
			//mPager.SetBackgroundColor(Android.Graphics.Color.Argb(200, 235, 235, 235));

			tabLayout = FindViewById<TabLayout>(Resource.Id.tabs_login);
			setViewPager();
			linear.StartAnimation(anim_menu);



		}


		public override void OnBackPressed()
		{
			if (mPager.CurrentItem == 0)
			{
				// If the user is currently looking at the first step, allow the system to handle the
				// Back button. This calls finish() on this activity and pops the back stack.
				base.OnBackPressed();
			}
			else {
				// Otherwise, select the previous step. minimizar la app

			}
		}

		public void setViewPager()
		{

			loginMenuFragment = new LoginMenuFragmnet();
			pageCustomAdapter = new PageCustomAdapter(SupportFragmentManager);
			pageCustomAdapter.addFragment(loginMenuFragment, "AFILIADO");
			pageCustomAdapter.addFragment(new LoginCargaFragment(), "CARGA");
			mPager.Adapter = pageCustomAdapter;
			tabLayout.SetupWithViewPager(mPager);
		}




	}
}

