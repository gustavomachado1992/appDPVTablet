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
	[Activity (Label = "Firs",ConfigurationChanges = ConfigChanges.Orientation ,ScreenOrientation = ScreenOrientation.SensorLandscape, WindowSoftInputMode = SoftInput.AdjustPan)]	
	public class Firs : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
		}
	}
}

