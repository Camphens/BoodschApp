using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Linq;
using System.Threading.Tasks;


namespace Boodschapp_PO4
{
    [Activity(Label = "boodschapp", MainLauncher = false, Theme = "@style/AppTheme")]
    public class explainScreen : Activity
    {
        TextView        Uitleg;
        ImageView       browsescreen, list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.explainScreen);
            Uitleg                  = FindViewById<TextView>(Resource.Id.uitleg);
            browsescreen            = FindViewById<ImageView>(Resource.Id.BrowseImageView);
            list                    = FindViewById<ImageView>(Resource.Id.ListImageView);
            browsescreen.Click      += Browsescreen_Click;
            list.Click              += List_Click;
        }

        void Browsescreen_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(BrowsingScreen1Activity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }

        void List_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(GrocerylistActivity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }

    }
}
