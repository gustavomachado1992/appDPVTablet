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
	[Activity (Label = "PDVTablet", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.SensorLandscape, WindowSoftInputMode = SoftInput.AdjustPan )]
	public class MainActivity : Activity
	{
	

		protected override void OnCreate (Bundle bundle)
		{
		
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Firs);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.buttonFirs);
			
			button.Click += delegate {

				StartActivity(typeof(telaLogin));


			};
		}
	}
}


