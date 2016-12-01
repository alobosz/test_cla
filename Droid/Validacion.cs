using System;
namespace CLATest.Droid
{
	public class ValidacionRut
	{
		private string rut;

		public ValidacionRut(string rut)
		{
			this.rut = rut;


		}
		/*
		void btningresar_clicked(object sender, EventArgs e)
		{

			var rut = entry_rut.Text;
			//var pass = entry_pass.Text;
			//var user = new User { _rut = rut, _pass = pass };
			//this.Navigation.PushModalAsync(new MyPage(user));

			if (validarRut(rut))
			{
				DisplayAlert("ha logueado con ÉXITO!!", "Hola" + entry_rut, "OK");
				//Llamar servicio de login

			}
			else
			{
				DisplayAlert("Falló", "Credenciales invalidas" + entry_rut, "OK");
			}


		}*/

		public bool validarRut(string rut)
		{

			bool validacion = false;
			try
			{
				rut = rut.ToUpper();
				rut = rut.Replace(".", "");
				rut = rut.Replace("-", "");
				int rutAux = Convert.ToInt32(rut.Substring(0, rut.Length - 1));

				char dv = Convert.ToChar(rut.Substring(rut.Length - 1, 1));

				int m = 0, s = 1;
				for (; rutAux != 0; rutAux /= 10)
				{
					s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
				}
				if (dv == (char)(s != 0 ? s + 47 : 75))
				{
					validacion = true;
				}
			}
			catch (Exception)
			{
				validacion = false;
			}
			return validacion;
		}

		private void entry_rut_OnCompleted(object sender, EventArgs e)
		{
			//Run This action on KeyDown Return
			//string auxiliar_rut = formatearRut(rut.Text);

			//rut.Text = auxiliar_rut;


		}

		public string formatearRut(string rut)
		{
			int cont = 0;
			string format;
			if (rut.Length == 0)
			{
				return "";
			}
			else
			{
				rut = rut.Replace(".", "");
				rut = rut.Replace("-", "");
				format = "-" + rut.Substring(rut.Length - 1);
				for (int i = rut.Length - 2; i >= 0; i--)
				{
					format = rut.Substring(i, 1) + format;
					cont++;
					if (cont == 3 && i != 0)
					{
						format = "." + format;
						cont = 0;
					}
				}
				return format;
			}
		}

	}
}
