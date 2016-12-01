using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace CLATest.Droid
{
	public class FragmentCuentaBancaria : Fragment
	{
		ViewGroup v;
		EditText et_cuenta;
		Spinner banco, tipocuenta;
		Button button;
		CheckBox check;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			v =  (ViewGroup)inflater.Inflate(Resource.Layout.cuenta_bancaria_fragment, container, false);
			et_cuenta = (EditText)v.FindViewById(Resource.Id.et_n_cuenta);
			banco = (Spinner)v.FindViewById(Resource.Id.sp_banco);
			tipocuenta = (Spinner)v.FindViewById(Resource.Id.sp_tipo_cuenta);
			button = (Button)v.FindViewById(Resource.Id.btn_update_bancaria);
			check = (CheckBox)v.FindViewById(Resource.Id.checkBox);
			button.Enabled = false;
			//435250781 numero atencion area baja
			/*
			banco.Click += delegate {

				et_cuenta.Enabled = true;
				//et_cuenta.SetRawInputType(Android.Text.InputTypes.ClassNumber);
				//et_cuenta.Focusable = true;
				Toast.MakeText(Activity, "entro al ontouch", ToastLength.Short).Show();

			};
			*/

			button.Click += delegate {
				Toast.MakeText(Activity, "Datos guardados", ToastLength.Short).Show();
			};

			check.CheckedChange += delegate {
				
				et_cuenta.Enabled = true;
				button.Enabled = true;
			};
			return v;
			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}
