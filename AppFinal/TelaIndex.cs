using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Security;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Provider;
using Android.Views.InputMethods;
using Android.Net;
using Android.Webkit;
using Android.Content.PM;
using Android.Content.Res;
using BR.Com.Daruma.Framework.Mobile;
namespace AppFinal
{
	[Activity (Label = "telaIndex",ConfigurationChanges = ConfigChanges.Orientation , ScreenOrientation = ScreenOrientation.SensorLandscape,WindowSoftInputMode = SoftInput.AdjustPan)]			
	public class TelaIndex : Activity
	{
		View viewMain;
		IEnumerable<ObjetoProduto> ProdEnumerable;
		List<ObjetoProduto> vinhoprod = new List<ObjetoProduto>();
		LayoutInflater inflater;
		private ClassProduto pegaProduto = new ClassProduto();
		public LinearLayout mainMain;

		public void handleFav(object obj,EventArgs args){

			//int youWant  = (int)((View)obj).Tag;

			var produto = pegaProduto.getVinho2 ();

			produto.DESCRICAO = "Produto Teste";
			produto.QTD = 20;
			produto.Valor = 20020;

			pegaProduto.saveProdutos(produto.ID_Produto, produto.DESCRICAO, produto.QTD, produto.Valor);
			Console.WriteLine ("false nao favoritado"+ produto.ID_Produto);

			}

		 

		protected override void OnCreate (Bundle bundle)
		{

			String strSocket = "@FRAMEWORK(TRATAEXCECAO=TRUE;LOGMEMORIA=200);@SERIAL(PORTA=0;VELOCIDADE=115200)";
			String strSocket2 = "@FRAMEWORK(TRATAEXCECAO=TRUE;LOGMEMORIA=200);@SOCKET(HOST=192.168.210.171;PORT=4001)";
			DarumaMobile objDa = DarumaMobile.Inicializar(this,strSocket);

		
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.telaIndex);
			mainMain = FindViewById<LinearLayout> (Resource.Id.layoutLista);
			mainMain.SetGravity (GravityFlags.Center);
			Button button = FindViewById<Button> (Resource.Id.bt_soma);
			ProdEnumerable = pegaProduto.getVinho2();
			vinhoprod = ProdEnumerable.ToList ();

			if (vinhoprod.Count < 1 ) {
				Console.WriteLine (""+vinhoprod);
				View view = inflater.Inflate(Resource.Layout.listaRowProduto, mainMain);
			
			} else {
				viewMain.FindViewById<ListView>(Resource.Id.mainLista).Adapter = new adapterProduto(this,vinhoprod, handleFav);
				//viewMain.FindViewById<ListView>(Resource.Id.mainLista).ItemClick += OnListItemClick;
			}
			button.Click += delegate {

				objDa.IniciarComunicacao ();

				try{
					objDa.EnviarComando("" + ((char) 0x1B) + "@" + ((char) 0x1B)
						+ "j1" + ((char) 0x1B) + "" + ((char) 0x45) + ""
						+ ((char) 0x0E) + "Brasystem" + ((char) 0x1B)
						+ "j0" + ((char) 0x0A) + "" + ((char) 0x0A) + ""
						+ ((char) 0x1B) + "" + ((char) 0x46) + ""
						+ ((char) 0x14) + ((char) 0x09)
						+ "Sistemas para automação comercial"
						+ ((char) 0x0A) + "" + ((char) 0x0A) + ""
						+ ((char) 0x0A) + "" + ((char) 0x0A));
					objDa.EnviarComando("" + ((char) 0x1B) + "" + ((char) 0x81)
						+ "Cod. Descrição Preco Uni. Sub.Total" + ((char) 0x29) + ""
						+ ((char) 0x0A) + "" + ((char) 0x0A) + ""
						+ ((char) 0x00) + "" + ((char) 0x07)
						+ ((char) 0x00) + "" + "");
					objDa.EnviarComando("" + ((char) 0x1B) + "" + ((char) 0x81)
						+ ((char) 0x29) + ""
						+ ((char) 0x00) + "" + ((char) 0x07)
						+ ((char) 0x00) + "" + "");

					objDa.EnviarComando("" + ((char) 0x1B) + "" + ((char) 0x81)
						+ "" + ((char) 0x29) + "" + ((char) 0x00) + ""
						+ ((char) 0x07) + ((char) 0x00)
						+ "http://www.Brasystem.com.br" + ""
						+ ((char) 0x1B) + "j0" + ((char) 0x19) + ""
						+ ((char) 0x19) + "" + ((char) 0x1B) + ""
						+ ((char) 0x6D));

					objDa.ACFAbrir_NFCe("","","","","","","","","");
					objDa.ACFVender_NFCe("12","1", "10",  "D$",  "0", "10",  "UNI",  "Produto 1");
					objDa.ACFTotalizar_NFCe("D$", "0");
					objDa.ACFEfetuarPagamento_NFCe("Dinheiro","10");
					objDa.TCFEncerrar_NFCe("Finalizada NFCe de demonstracao");
				}catch(Exception exc){
					String[] log = new String[200];
					objDa.MostrarLog(log);
					String msg = exc.Message.ToString();
				}

			};
		}
	}
}

