
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
			
	public class ObjetoLoja  : Java.Lang.Object
	{
	public int ID_Produto { get; set; }
	public string RAZAO { get; set; }
	public string FANTASIA { get; set; }
	public string CNPJ { get; set; }
	public string ENDERECO { get; set; }
	public string CIDADE { get; set; }
	public string UF { get; set; }
	public DateTime DATA { get; set; }

		public ObjetoLoja (int id_loja, string razao,string fantasia, string cnpj, string endereco, string cidade, string uf, DateTime data)
		{
			id_loja = id_loja;
			RAZAO = razao;
			FANTASIA = fantasia;
			ENDERECO = endereco;
			CIDADE = cidade;
			UF = uf;
			CNPJ = cnpj;
			DATA = data;
		}
	}
}