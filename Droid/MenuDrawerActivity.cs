using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Support.V4.View;
using Android.Gms.Maps;
using Android.App;
using Android.Widget;
using Android.Content.PM;

namespace CLATest.Droid
{
	[Activity(Label = "MenuDrawerActivity", Theme = "@style/AppTheme.Drawer", WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MenuDrawerActivity : AppCompatActivity
	{
		FragmentInbox fragmentInbox;
		FragmentMiCuenta fragmentMapa;
		HomeFragment homeFragment;
		//	MapFragment _myMapFragment;
		//FragmentCertificados fragmentCertificados;
		//FragmentConvenios fragmentConvenios;
		//FragmentCreditos fragmentCreditos;
		//FragmentLicencias fragmentLicencias;
		DrawerLayout drawerLayout;
		public Android.Support.V7.Widget.Toolbar toolbar;
		//ImageView fotoheader;
		 
		public Android.Support.V4.App.FragmentManager fragmentManager;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Maindrawer);
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			var ft = SupportFragmentManager.BeginTransaction();

			// Initialize toolbar
			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetTitle(Resource.String.home);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetDisplayShowHomeEnabled(true);


			//fotoheader = (ImageView)FindViewById(Resource.Id.imageView);

			//fotoheader.Click += delegate {
				//fragmentManager = SupportFragmentManager;
				//var ftra = fragmentManager.BeginTransaction();
				//ftra.Replace(Resource.Id.HomeFrameLayout, new FragmentDatos());
				//ftra.Commit();
				//SupportActionBar.SetTitle(Resource.String.mi_cuenta);

//			};





			// Attach item selected handler to navigation view
			var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

			// Create ActionBarDrawerToggle button and add it to the toolbar
			var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
			drawerLayout.AddDrawerListener(drawerToggle);
			drawerToggle.SyncState();


			//Load default screen

			//ft.AddToBackStack(null);
			ft.Replace(Resource.Id.HomeFrameLayout, new HomeFragment());
			ft.Commit();

		}
		void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
		{
			var ft2 = SupportFragmentManager.BeginTransaction();
			toolbar.Elevation=8;
			switch (e.MenuItem.ItemId)
			{
				case (Resource.Id.nav_home):
					SupportInvalidateOptionsMenu();
					homeFragment = new HomeFragment();
					ft2.Replace(Resource.Id.HomeFrameLayout, homeFragment);
					ft2.Commit();
					SupportActionBar.SetTitle(Resource.String.home);
					break;

				case (Resource.Id.nav_mi_cuenta):
					SupportInvalidateOptionsMenu();
					fragmentMapa = new FragmentMiCuenta(SupportFragmentManager);
					ft2.Replace(Resource.Id.HomeFrameLayout, fragmentMapa);
					ft2.Commit();
					SupportActionBar.SetTitle(Resource.String.mi_cuenta);
					break;

				case (Resource.Id.nav_inbox):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.inbox);
					break;

				case (Resource.Id.nav_sucursales):
					
					ft2.Replace(Resource.Id.HomeFrameLayout, new FragmentMaps(SupportFragmentManager));
					ft2.Commit();

					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.sucursales);
					break;

				case (Resource.Id.nav_convenios):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.convenios);
					break;
				case (Resource.Id.nav_licencias):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.licencias);
					break;
				case (Resource.Id.nav_creditos):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.creditos);
					break;
				case (Resource.Id.nav_certificados):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.certificados);
					break;
				case (Resource.Id.nav_ayuda):
					// React on 'Friends' selection
					SupportActionBar.SetTitle(Resource.String.ayuda);
					break;
				case (Resource.Id.nav_signout):
					// React on 'Friends' selection
					Finish();
					break;
			}
			// Close drawer
			drawerLayout.CloseDrawers();
		}



		//to avoid direct app exit on backpreesed and to show fragment from stack
		public override void OnBackPressed()
		{
			DrawerLayout drawer = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);
			if (drawer.IsDrawerOpen(GravityCompat.Start))
			{
				drawer.CloseDrawer(GravityCompat.Start);
			}
			else {
				base.OnBackPressed();
			}
		}

	}

}
