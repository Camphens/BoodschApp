using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Boodschapp_PO4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
    public class FSplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splasher);
            TheTransition();

        }

        async void TheTransition()
        {
            var intent = new Intent(this, typeof(BrowsingScreen1Activity));
            await Task.Delay(4000);
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }
    }
}