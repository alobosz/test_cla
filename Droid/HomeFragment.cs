using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;


namespace CLATest.Droid
{
	public class HomeFragment : Fragment
	{
		ImageButton imBoton;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_home, container, false);
			imBoton = (ImageButton)v.FindViewById(Resource.Id.btn_ayuda_home);

			//Glide.With(Activity).Load("http://ketquaviet.vn/app/img/logo-kqv.png")
			     //.Transform(new CircleTransform(Activity))
				//.Into(image);



			return v;
		}
	}
}
