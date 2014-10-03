using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Provider;
using System.Threading.Tasks;

namespace AppFinal
{	
	public class adapterProduto :BaseAdapter<ObjetoProduto>
	{
		Android.Net.Uri imagemData;
		List<ObjetoProduto> items;
		Activity context;

		private EventHandler buttonClick;
		private EventHandler clickFav;
		private ClassProduto pegaProduto = new ClassProduto();

		public adapterProduto(Activity context, List<ObjetoProduto> items, EventHandler buttonFav )
			: base()
		{
			this.context = context;
			this.items = items;
			//this.buttonClick = buttonCallBack;
			this.clickFav = buttonFav;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override ObjetoProduto this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{

			var item = items [position];
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate (Resource.Layout.listaRowProduto, null);
	
			Console.WriteLine (item.DESCRICAO);
			view.FindViewById<TextView> (Resource.Id.desPoduto).Text = item.DESCRICAO;
			view.FindViewById<TextView> (Resource.Id.desPoduto).SetSingleLine ();
			Console.WriteLine (item.DESCRICAO);
			view.FindViewById<TextView> (Resource.Id.valPoduto).Text = string.Format ("{0:0.00}", item.Valor);
			view.FindViewById<TextView> (Resource.Id.codPoduto).Text = Convert.ToString(item.ID_Produto);
			view.FindViewById<TextView> (Resource.Id.qtdPoduto).Text = Convert.ToString (item.QTD);

		
			return view;
		}
		
		}

	}


