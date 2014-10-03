
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
			
	public class ObjetoProduto : Java.Lang.Object
	{
		public int ID_Produto { get; set; }
		public string DESCRICAO { get; set; }
		public int QTD { get; set; }
		public int Valor { get; set; }

		public ObjetoProduto (int id_produto, string descricao, int id_qtd, int id_valor)
		{
			ID_Produto = id_produto;
			DESCRICAO = descricao;
			QTD = id_qtd;
			Valor = id_valor;
		}
	}
}

