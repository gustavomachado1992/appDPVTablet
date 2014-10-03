
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

	public class ObjetoVendaItem : Java.Lang.Object
	{
		public int ID_VENDA_ITEM { get; set; }
		public int PRODUTO_VENTDAITEM { get; set; }
		public int VENDA_VENDAITEM { get; set; }
		public int QTD { get; set; }
		public int VALOR { get; set; }
		public DateTime DATA { get; set; }

		public ObjetoVendaItem(int id_vendaItem, int produto_vendaItem, int venda_vendaItem, int qtd, int id_valor, DateTime data )
		{
			ID_VENDA_ITEM = id_vendaItem;
			PRODUTO_VENTDAITEM = produto_vendaItem;
			VENDA_VENDAITEM = venda_vendaItem;
			QTD = qtd;
			VALOR = id_valor;
			DATA = data;
		}
	}
}

