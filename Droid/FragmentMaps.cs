
using System;
using Android.Gms.Common;
using Android.Gms.Location.Places.UI;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace CLATest.Droid
{
	public class FragmentMaps : Fragment, IOnMapReadyCallback, GoogleMap.IOnMarkerClickListener
	{
		//private GoogleMap mMap;
		private static readonly int CODIGO_SOLICITUD_SERVICIO = 1;
		//MenuDrawerActivity activity;
		ViewGroup v;
		FragmentManager fm;
		GoogleMap map;
		SupportMapFragment mf;
		WeakHashMap mMarkers;

		public FragmentMaps(FragmentManager fm) {

			this.fm = fm;

		}


		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//activity = (MenuDrawerActivity)Activity;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			v = (ViewGroup)inflater.Inflate(Resource.Layout.maps_fragment, container, false);



			mf = (SupportMapFragment)ChildFragmentManager.FindFragmentById(Resource.Id.map);
			mf.GetMapAsync(this);


			return v;

			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

		}




		public void OnMapReady(GoogleMap googleMap)
		{
			map = googleMap;
			if (map != null)
			{
				BitmapDescriptor subwayBitmapDescriptor = BitmapDescriptorFactory.FromResource(Resource.Mipmap.mk_localizacion);
				LatLng location = new LatLng(-33.454528, -70.599851);
				//MapsInitializer.Initialize(activity);
				Marker marker = map.AddMarker(new MarkerOptions().SetPosition(location).SetTitle("Sucursal Caja Los Andes - Ñuñoa").SetIcon(subwayBitmapDescriptor));
				marker.ShowInfoWindow();



				map.MoveCamera(CameraUpdateFactory.NewLatLng(location));
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(location);
				builder.Zoom(10);
				builder.Bearing(155);
				builder.Tilt(65);
				CameraPosition cameraPosition = builder.Build();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
				map.MoveCamera(cameraUpdate);
				mMarkers = new WeakHashMap();
				mMarkers.Put(marker, "suc_nunoa");

				map.SetOnMarkerClickListener(this);




			}

			else {
				Toast.MakeText(Activity, "No se ha podido cargar el mapa", ToastLength.Short).Show();
			}


			/*
			LatLng location = new LatLng(50.897778, 3.013333);
			MapsInitializer.Initialize(activity);
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(location);
			builder.Zoom(18);
			builder.Bearing(155);
			builder.Tilt(65);
			CameraPosition cameraPosition = builder.Build();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
			map.MoveCamera(cameraUpdate);*/
		}

		public bool OnMarkerClick(Marker marker)
		{
			string sucursal = mMarkers.Get(marker).ToString();
			Toast.MakeText(Activity, "El marcardor tiene ID:" + sucursal, ToastLength.Short).Show();
			var builder = new PlacePicker.IntentBuilder();
			StartActivityForResult(builder.Build(Activity), 1); 
			return false;
		}
	}













	/**Forma validad de hacer los mapas de forma dinamica
		 * 
		 mf = new SupportMapFragment();
		 var ft = fm.BeginTransaction();
		 ft.Replace(Resource.Id.map, mf);
		 ft.Commit();
		 mapActions();
		 * 
		 * 

		void mapActions()
		{
			try
			{
				MapsInitializer.Initialize(activity);
				LatLng location = new LatLng(50.897778, 3.013333);
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(location);
				builder.Zoom(18);
				builder.Bearing(155);
				builder.Tilt(65);
				CameraPosition cameraPosition = builder.Build();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
				mMap.MoveCamera(cameraUpdate);
			}
			catch (GooglePlayServicesNotAvailableException e)
			{
				e.PrintStackTrace();
			}

		} * 
		 * 
		 * 
		 */
}
