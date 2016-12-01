using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace CLATest.Droid
{
	public class FragmentIntereses : Fragment, View.IOnClickListener
	{
		ViewGroup viewroot;
		ImageButton belleza, viajes, deporte, teatro, redes, cine, educacion, gastro, musica; 
		/*
		 * Ids
		img_belleza
		img_viajes
		img_deporte
		img_teatro
		img_redes
		img_cine
		img_educacion
		img_gastro
		img_musica
		*/
		int fbelleza, fviajes, fdeporte, fteatro, fredes, fcine, feducacion, fgastro, fmusica;
		View view;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			RetainInstance = true;

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment


			viewroot = (ViewGroup)inflater.Inflate(Resource.Layout.interteses_fragment, container, false);




			belleza = (ImageButton)viewroot.FindViewById(Resource.Id.img_belleza);
			viajes = (ImageButton)viewroot.FindViewById(Resource.Id.img_viajes);
			deporte = (ImageButton)viewroot.FindViewById(Resource.Id.img_deporte);
			teatro = (ImageButton)viewroot.FindViewById(Resource.Id.img_teatro);
			redes= (ImageButton)viewroot.FindViewById(Resource.Id.img_redes);
			cine = (ImageButton)viewroot.FindViewById(Resource.Id.img_cine);
			educacion = (ImageButton)viewroot.FindViewById(Resource.Id.img_educacion);
			gastro = (ImageButton)viewroot.FindViewById(Resource.Id.img_gastro);
			musica = (ImageButton)viewroot.FindViewById(Resource.Id.img_musica);

			/*
			belleza.Click += delegate {

				if (fbelleza == 0)
				{
					belleza.SetAlpha(45);
					fbelleza = 1;

				}
				else { 
					belleza.SetImageResource(Resource.Mipmap.im_belleza);
					fbelleza = 0;
					belleza.SetAlpha();
				}
			};*/
			belleza.SetOnClickListener(this);
			viajes.SetOnClickListener(this);
			deporte.SetOnClickListener(this);
			teatro.SetOnClickListener(this);
			redes.SetOnClickListener(this);
			cine.SetOnClickListener(this);
			educacion.SetOnClickListener(this);
			gastro.SetOnClickListener(this);
			musica.SetOnClickListener(this);

			return viewroot;
			//return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public void OnClick(View v)
		{
			ImageView image = (ImageView)v;

			if (image.HasFocusable)
			{
				image.Focusable = false;

				image.SetAlpha(45);

			}

			else {
				image.Focusable = true;
				image.SetAlpha(255);
			}


		}
	}
}
