

using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;

namespace CLATest.Droid
{
	public class FragmentDatos : Fragment
	{
		ViewGroup v;
		MenuDrawerActivity activity;
		//Toolbar toolbarf;
		EditText direccion, comuna, ciudad, region, fijo, movil, mail;
		Button facebook;
		ImageView image;


		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			activity = (MenuDrawerActivity)Activity;
			//HasOptionsMenu = true;
			// Create your fragment here
			//RetainInstance = true;
			//activity.SupportInvalidateOptionsMenu();



		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			// Use this to return your custom view for this Fragment  et_rut_cliente, et_nombre_cliente
		// et_mail_cliente, ic2, ic23 , ic32, ic42, btn_facebook

			v = (ViewGroup)inflater.Inflate(Resource.Layout.perfil_fragment, container, false);

			direccion = (EditText)v.FindViewById(Resource.Id.et_rut_cliente);
			comuna = (EditText)v.FindViewById(Resource.Id.et_nombre_cliente);
			ciudad = (EditText)v.FindViewById(Resource.Id.et_mail_cliente);
			region = (EditText)v.FindViewById(Resource.Id.ic2);
			fijo = (EditText)v.FindViewById(Resource.Id.ic23);
			movil = (EditText)v.FindViewById(Resource.Id.ic32);
			mail = (EditText)v.FindViewById(Resource.Id.ic42);
			image = (ImageView)v.FindViewById(Resource.Id.img_cliente);
			//facebook = (Button)v.FindViewById(Resource.Id.btn_facebook);
			desactivarTextviews();
			/*
			image.Click += delegate
			 {
				 var imageIntent = new Intent();
				 imageIntent.SetType("image/*");
				 imageIntent.SetAction(Intent.ActionGetContent);
				 StartActivityForResult(
					 Intent.CreateChooser(imageIntent, "Seleccione Imagen"), 0);
			 };*/

			/*
			facebook.Click+= delegate {
				Toast.MakeText(Activity, "Se Han Obtenido tus intereses de Facebook", ToastLength.Short).Show();
			};
*/

			//activity = (MenuDrawerActivity)Activity;

			//activity.toolbar = toolbarf;
			//activity.SetSupportActionBar(activity.toolbar);
			//activity.SupportActionBar.SetTitle(Resource.String.app_name);

			return v;
			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
		/*
		public override void OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode==111)
			{
				Toast.MakeText(Activity, "cambio de imagen perfil", ToastLength.Short).Show();
				image = (ImageView)v.FindViewById(Resource.Id.clave_triste);

				Glide.With(this)
				 .Load(data.Data)
				     .Transform(new CircleTransform(activity))
				.Into(image);

			}
		}*/




		public void desactivarTextviews() { 

			/*direccion = (EditText)v.FindViewById(Resource.Id.et_rut_cliente);
			comuna = (EditText)v.FindViewById(Resource.Id.et_nombre_cliente);
			ciudad = (EditText)v.FindViewById(Resource.Id.et_mail_cliente);
			region = (EditText)v.FindViewById(Resource.Id.ic2);
			fijo = (EditText)v.FindViewById(Resource.Id.ic23);
			movil = (EditText)v.FindViewById(Resource.Id.ic32);
			mail = (EditText)v.FindViewById(Resource.Id.ic42);
			facebook = (Button)v.FindViewById(Resource.Id.btn_facebook);*/

			direccion.Enabled = false;
			direccion.Focusable = false;
			direccion.Text = "Italia 850";

			comuna.Enabled = false;
			comuna.Focusable = false;
			comuna.Text = "Providencia";

			ciudad.Enabled = false;
			ciudad.Focusable = false;
			ciudad.Text = "Santiago";

			region.Enabled = false;
			region.Focusable = false;
			region.Text = "RM";

			fijo.Enabled = false;
			fijo.Focusable = false;


			movil.Enabled = false;
			movil.Focusable = false;
			movil.Text = "(9)87654321";

			mail.Enabled = false;
			mail.Focusable = false;
			mail.Text = "juan@cajalosandes.cl";
		
		}
		/*
		public void activarTextviews() { 
			


			direccion.Enabled = true;
			direccion.Focusable = true;
			direccion.Text = "Italia 850";

			comuna.Enabled = true;
			comuna.Focusable = true;
			comuna.Text = "Providencia";

			ciudad.Enabled = true;
			ciudad.Focusable = true;
			ciudad.Text = "Santiago";

			region.Enabled = true;
			region.Focusable = true;
			region.Text = "RM";

			fijo.Enabled = true;
			fijo.Focusable = true;


			movil.Enabled = true;
			movil.Focusable = true;
			movil.Text = "(9)87654321";

			mail.Enabled = true;
			mail.Focusable = true;
			mail.Text = "juan@cajalosandes.cl";

		
		}


		*/
	}
}
