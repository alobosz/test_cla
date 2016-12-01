

using System;
using Android.Gms.Maps;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace CLATest.Droid
{
	public class FragmentMiCuenta : Android.Support.V4.App.Fragment, IOnMapReadyCallback, ViewPager.IOnPageChangeListener
	{
		MapFragment _map;
		AdapterMiCuenta adapterMiCuenta;
		LoginMenuFragmnet loginMenuFragment;
		FragmentManager fm;
		LinearLayout linear;
		TabLayout mTabLayout;
		ViewPager mViewPager;
		Button b;
		int id;
		MenuDrawerActivity activity;
		//Toolbar toolbar;
		int pagina;

		public FragmentMiCuenta(FragmentManager fm){
			this.fm = fm;

		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			activity = (MenuDrawerActivity)Activity;
			activity.toolbar.Elevation = 0;
			pagina = 0;
			HasOptionsMenu = true;
			RetainInstance = true;

			// Create your fragment here

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			ViewGroup v = (ViewGroup) inflater.Inflate(Resource.Layout.fragment_mi_cuenta, container, false);
			//LoginCargaFragment lf = new LoginCargaFragment();
			//b = (Button)v.FindViewById(Resource.Id.boton_mapa);
			mViewPager = (ViewPager)v.FindViewById(Resource.Id.pager_mi_cuenta);
			mTabLayout = (TabLayout)v.FindViewById(Resource.Id.tabs_mi_cuenta);

			//linear= (LinearLayout)v.FindViewById(Resource.Id.container_in_mapfrag);
			//id = linear.Id;
			//id = Resource.Id.container_in_mapfrag;
			setViewPager();





			//b.Click += delegate
			//{
				//reemplazarFragment(lf, id);

			//};

			return v;




			//return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);


		}



		public void reemplazarFragment(Fragment fragment, int id)
		{
			var ft = fm.BeginTransaction();
			ft.Replace(id, fragment);
			ft.Commit();

		}

		public void setViewPager()
		{

			//loginMenuFragment = new LoginMenuFragmnet();
			adapterMiCuenta = new AdapterMiCuenta(fm);
			adapterMiCuenta.addFragment(new FragmentDatos(), "DATOS");
			adapterMiCuenta.addFragment(new FragmentIntereses(), "INTERESES");
			adapterMiCuenta.addFragment(new FragmentCuentaBancaria(), "CUENTA BANCARIA");
			mViewPager.Adapter = adapterMiCuenta;
			mTabLayout.SetupWithViewPager(mViewPager);
			mViewPager.CurrentItem = pagina;
			mViewPager.AddOnPageChangeListener(this);

		}


		public override void OnPrepareOptionsMenu(IMenu menu)
		{
			switch (pagina) {
				case (0):
					activity.MenuInflater.Inflate(Resource.Menu.menu_registrar, menu);
					menu.FindItem(Resource.Id.action_ok).SetVisible(false);
					break;
				case (1):
					//activity.MenuInflater.Inflate(Resource.Menu.action_menu, menu);
					break;	
			
			}

			base.OnPrepareOptionsMenu(menu);
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			
		}

		public void OnPageScrollStateChanged(int state)
		{
			
		}

		public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			
		}

		public void OnPageSelected(int position)
		{
			activity.SupportInvalidateOptionsMenu();
			pagina = position;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Resource.Id.action_editar) {
				Toast.MakeText(activity, "Datos bloqueados temporalmente", ToastLength.Short).Show();

				//var datos = new FragmentDatos();
				//datos.activarTextviews();
			}
				
				
			return base.OnOptionsItemSelected(item);
		}
	}
}
