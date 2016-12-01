using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using Java.Lang;

namespace CLATest.Droid
{
	public class AdapterMiCuenta : FragmentStatePagerAdapter
	{

		//editado
		List<Fragment> mfragments = new List<Fragment>();
		List<string> mFragmentTitleList = new List<string>();
		//static readonly int NUM_PAGES_PROFILE = 2;
		//editado


		public AdapterMiCuenta(FragmentManager fm) : base(fm) {


		}

		public override int Count
		{
			get
			{
				return mfragments.Count;
			}
		}

		public override Fragment GetItem(int position)
		{
			return mfragments[position];
		}

		//esditado
		public void addFragment(Fragment fragment, string title)
		{
			mfragments.Add(fragment);
			mFragmentTitleList.Add(title);
		}
		//editado

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(mFragmentTitleList[position].ToLower());

		}
	}
}


