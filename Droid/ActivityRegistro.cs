

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;

namespace CLATest.Droid
{
	[Activity(Label = "ActivityRegistro", Theme = "@style/AppTheme.Drawer", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan)]
	public class ActivityRegistro : AppCompatActivity
	{
		ImageView image;
		Android.Support.V7.Widget.Toolbar toolbar;
		EditText direccion, comuna, ciudad, region, fijo, movil, mail;
		Button boton;
		//private SlidingUpPanelLayout mLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			SetContentView(Resource.Layout.sliding_up_panel);
			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetTitle(Resource.String.registrar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetDisplayShowHomeEnabled(true);


			image = (ImageView)FindViewById(Resource.Id.img_cliente_registro);





			image.Click += delegate
			 {
				 var imageIntent = new Intent();
				 imageIntent.SetType("image/*");
				 imageIntent.SetAction(Intent.ActionGetContent);
				 StartActivityForResult(
					 Intent.CreateChooser(imageIntent, "Seleccione Imagen"), 0);
			 };


			/*
			direccion.FindViewById(Resource.Id.et_rut_cliente_registro);
			comuna.FindViewById(Resource.Id.et_serie_cliente_registro);
			ciudad.FindViewById(Resource.Id.et_mail_cliente_registro);
			region.FindViewById(Resource.Id.et_movil_registro);
			fijo.FindViewById(Resource.Id.et_fijo_registro);
			movil.FindViewById(Resource.Id.et_repetir_pass);
			mail.FindViewById(Resource.Id.et_repetir_pass_2);*/





		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok)
			{

				image = (ImageView)FindViewById(Resource.Id.img_cliente_registro);

				Glide.With(this)
				 .Load(data.Data)
				.Transform(new CircleTransform(this))
				.Into(image);

			}
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_registrar, menu);
			if (menu != null)
			{
				//menu.FindItem(Resource.Id.action_refresh).SetVisible(true);
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
					Toast.MakeText(this, "Guardando Datos", ToastLength.Short).Show();
					item.SetVisible(false);
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
