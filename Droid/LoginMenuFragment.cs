using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Lang;

namespace CLATest.Droid
{
	public class LoginMenuFragmnet : Android.Support.V4.App.Fragment
	{



		Button boton;
		ImageView imagen;
		Intent i;
		EditText et_rut;
		EditText et_pass;
		TextView tv_registrar;
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);



			ViewGroup rootView = (ViewGroup)inflater.Inflate(
				Resource.Layout.fragment_login_menu, container, false);
			boton = (Button)rootView.FindViewById(Resource.Id.botonLogin);
			imagen = (ImageView)rootView.FindViewById(Resource.Id.img_olvidar_clave);
			et_rut = (EditText)rootView.FindViewById(Resource.Id.rut);
			et_pass = (EditText)rootView.FindViewById(Resource.Id.password);
			tv_registrar = (TextView)rootView.FindViewById(Resource.Id.registrar);
			ICharSequence derp = new Java.Lang.String("hello");



				et_rut.TextChanged += delegate
				{
					if (string.IsNullOrEmpty(et_rut.Text))
					{

						//et_rut.RequestFocus();
						//et_rut.SetError(derp, Resources.GetDrawable(Resource.Mipmap.olvidar_clave));
					}
				};

		






			boton.Click += delegate
			{
				login();
			};

			imagen.Click += delegate
			{
				olvidarClave();
			};


			tv_registrar.Click += delegate
			{
				registrar();
			};



			return rootView;
		}




	




		public void login()
		{
			i = new Intent(Activity.BaseContext, typeof(MenuDrawerActivity));
			StartActivity(i);

		}

		void registrar()
		{
			i = new Intent(Activity.BaseContext, typeof(ActivityRegistro));
			StartActivity(i);
		}

		void olvidarClave()
		{
			i = new Intent(Activity.BaseContext, typeof(ActivityCambiarClave));
			StartActivity(i);
		}
	}
}