﻿using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace CLATest.Droid
{
	public class FragmentClaveNueva : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			return inflater.Inflate(Resource.Layout.clave_nueva_fragment, container, false);

			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}
