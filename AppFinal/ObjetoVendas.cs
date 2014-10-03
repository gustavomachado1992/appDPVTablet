
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppFinal
{
			
	public class ObjetoVendas: Java.Lang.Object
	{
		public int ID_VENDA { get; set; }
		public int TOTAL { get; set; }
		public int OPERADOR { get; set; }
		public DateTime DATA { get; set; }


		public ObjetoVendas(int id_cod, int id_total, int id_operador, DateTime data)
		{
			ID_VENDA = id_cod;
			TOTAL = id_total;
			OPERADOR = id_operador;
			DATA = data;
		}
	}
}

