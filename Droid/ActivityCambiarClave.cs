using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CLATest.Droid
{
	[Activity(Label = "ActivityCambiarClave", Theme = "@style/AppTheme.Drawer", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan)]
	public class ActivityCambiarClave : AppCompatActivity
	{
		Android.Support.V4.App.FragmentManager fm;
		Android.Support.V7.Widget.Toolbar toolbar;
		Android.Support.V4.App.FragmentTransaction ft2;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.clave_cambio_activity);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetTitle(Resource.String.olvido_pass);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetDisplayShowHomeEnabled(true);
			fm = SupportFragmentManager;
			var ft = fm.BeginTransaction();
			ft.Replace(Resource.Id.cambio_clave_container, new FragmentClaveRecuperar());
			ft.Commit();
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_registrar, menu);
			if (menu != null)
			{
				menu.FindItem(Resource.Id.action_ok).SetVisible(true);
				menu.FindItem(Resource.Id.action_editar).SetVisible(false);


			}
			return base.OnCreateOptionsMenu(menu);
		}

		//define action for tolbar icon press
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.action_ok:
					Toast.MakeText(this, "Ahora cree una nueva clave", ToastLength.Short).Show();

					ft2 = fm.BeginTransaction();
					ft2.Replace(Resource.Id.cambio_clave_container, new FragmentClaveNueva());
					ft2.Commit();
					return true;
				case Android.Resource.Id.Home:
					Finish();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
		//to avoid direct app exit on backpreesed and to show fragment from stack
		public override void OnBackPressed()
		{
			
			base.OnBackPressed();

		}


	}
}
