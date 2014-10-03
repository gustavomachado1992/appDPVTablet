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

namespace AppFinal
{
	[Activity (Label = "telaLogin",ConfigurationChanges = ConfigChanges.Orientation,ScreenOrientation = ScreenOrientation.SensorLandscape, WindowSoftInputMode = SoftInput.AdjustPan)]			
	public class telaLogin : Activity
	{
		public EditText editLogin;
		public EditText editSenha;
		public ProgressBar loader;
		public TextView txtLogin;
		public RelativeLayout btnLogin ;

		public void logar(){
			loader.Visibility = ViewStates.Visible;
			if (editLogin.Text == "" && editSenha.Text == "") {
				StartActivity (typeof(TelaIndex));

				Finish ();

			} else {
				Console.WriteLine ("-algo errado-");
				loader.Visibility = ViewStates.Invisible;
			}
		}
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.telaLogin);

			btnLogin = FindViewById<RelativeLayout> (Resource.Id.btnLogin);
			editLogin = FindViewById<EditText> (Resource.Id.editLogin);
			editSenha = FindViewById<EditText> (Resource.Id.editSenha);
			loader = FindViewById<ProgressBar> (Resource.Id.loader);
			txtLogin = FindViewById<TextView> (Resource.Id.txtLogin);
			loader.Visibility = ViewStates.Invisible;
			var btnCfg = FindViewById<LinearLayout> (Resource.Id.btnCfg);

			btnLogin.Click += delegate {
				logar ();

			};
			btnCfg.Click += delegate {
				StartActivity(typeof(TelaCfg));
			};

		}
	}
}