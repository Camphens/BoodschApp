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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class BrowsingScreen2Activity : AppCompatActivity
    {
        RecyclerView                    mRecyclerView;
        RecyclerView.LayoutManager      mLayoutManager;
        BrowsingGroupAdapter            mAdapter;
        ProductList                     mProductList;
        Button                          button;
        ImageView                       ButtonGroceries, ButtonHelp;

        ProductCategory                 CategoryID;
        int                             waiter = 0;
        List<string>                    ListOfProducts = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.BrowsingLayout1);

            mRecyclerView       = FindViewById<RecyclerView>(Resource.Id.recyclerView1);



            if (this.Intent.Extras != null)
            {
                var category    = (ProductCategory)Intent.Extras.GetInt("CategoryID");
                var productlist = Intent.Extras.GetStringArray("lijst");

                CategoryID      = category;
                ListOfProducts  = productlist.ToList();
            }

            mProductList        = new ProductList(CategoryID);

            //button              = FindViewById<Button>(Resource.Id.button1);
            ButtonGroceries     = FindViewById<ImageView>(Resource.Id.ListImageView);
            ButtonHelp          = FindViewById<ImageView>(Resource.Id.HelpImageView);

            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new BrowsingGroupAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;

            //button.Click += Button_Click; ;
            ButtonGroceries.Click   += List_Click;
            ButtonHelp.Click        += Help_Click;

            mRecyclerView.SetAdapter(mAdapter);

        }

        async void OnItemClick(object sender, int position)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(BrowsingScreen3Activity));

                Bundle b = new Bundle();
                b.PutInt("CategoryID", (int)mProductList[position].category);
                b.PutInt("GroupID", (int)mProductList[position].group);
                b.PutStringArray("lijst", ListOfProducts.ToArray());
                intent.PutExtras(b);

                //Toast.MakeText(this, "This is in group " + mProductList[position].group, ToastLength.Short).Show();
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }


        async void List_Click(object sender, EventArgs e)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(GrocerylistActivity));

                intent.PutExtra("lijst", ListOfProducts.ToArray());
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }

        async void Help_Click(object sender, EventArgs e)
        {
            if (waiter == 0)
            {
                waiter += 1;
                var intent = new Intent(this, typeof(explainScreen));

                //intent.PutExtra("lijst", ListOfProducts.ToArray());
                await Task.Delay(300);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                waiter = 0;
            }
        }
    }
}