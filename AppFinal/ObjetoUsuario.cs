
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

	public class ObjetoUsuario  : Java.Lang.Object
	{
		public int ID_USUARIO{ get; set; }
		public string NOME { get; set; }
		public string LOGIN { get; set; }
		public string SENHA { get; set; }
		public DateTime DATA { get; set; }
		public ObjetoUsuario (int id_usuario, string nome, string login, string senha, DateTime data )
		{
			ID_USUARIO = id_usuario;
			NOME = nome;
			LOGIN = login;
			SENHA = senha;
			DATA = data;
		}
	}
}