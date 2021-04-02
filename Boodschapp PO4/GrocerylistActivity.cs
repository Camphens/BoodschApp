using Android.App;
using System.Linq;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using PCLStorage;
using System.Threading.Tasks;
using Android.Content;
using System.IO;
using Android.Views;
using Android.Views.InputMethods;

namespace Boodschapp_PO4
{
    public class person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    [Activity(Label = "boodschapp", MainLauncher = true, Theme = "@style/AppTheme")]
    public class GrocerylistActivity : Activity
    {
        List<string>        mItems = new List<string>();
        ImageView           ButtonProducts, ButtonHelp;

        //TextView            textViewdemi, textViewexplain;
        ListView            mListView;
        EditText            editText1;
        ListviewAdapter     adapter;

        string fullPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
             "Grocerylist.txt");


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GrocerylistLayout);

            mListView           = FindViewById<ListView>(Resource.Id.mylistView);
            editText1           = FindViewById<EditText>(Resource.Id.editText1);
            adapter             = new ListviewAdapter(this, mItems);
            mListView.Adapter   = adapter;

            ButtonProducts      = FindViewById<ImageView>(Resource.Id.BrowseImageView);
            ButtonHelp          = FindViewById<ImageView>(Resource.Id.HelpImageView);
            //textViewdemi        = FindViewById<TextView>(Resource.Id.button3);
            //textViewexplain     = FindViewById<TextView>(Resource.Id.explain);


            //button.Click        += Button_Click;
            mListView.ItemClick += MListView_ItemClick;
            editText1.KeyPress  += EditText1_KeyPress;

            //textViewexplain.Click   += ButtonExplain_Click;
            //textViewdemi.Click      += TextViewdemi_Click;
            ButtonHelp.Click        += ButtonExplain_Click;
            ButtonProducts.Click    += TextViewdemi_Click;

            try
            {
                var storedjson1 = File.ReadAllText(fullPath);
                var newinstance1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(storedjson1);
                if (newinstance1.Any())
                {
                    foreach (var v in newinstance1)
                    {
                        Console.WriteLine(v);
                        mItems.Add(v);
                        adapter.NotifyDataSetChanged();

                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("error: empty list" + e);
            }
        }


        void EditText1_KeyPress(object sender, Android.Views.View.KeyEventArgs e)
        {
        if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
        e.Handled = true;
        DismissKeyboard();
        var editText = (EditText)sender;
        var currentItem = editText.Text;
        if (currentItem != "")
            {
                    mItems.Add(currentItem);
                adapter.NotifyDataSetChanged();
                editText.Text = "";
                string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(mItems, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(fullPath, jsonoutput);
            }


        if (currentItem == "")
                {

                }

            }
            else
                e.Handled = false;
        }


        private void DismissKeyboard()
        {
            var view = CurrentFocus;
            if (view != null)
            {
                var imm = (InputMethodManager)GetSystemService(InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        //void Button_Click(object sender, System.EventArgs e)
        //{


        //    var currentvar1 = editText1.Text;


        //


        //}

        void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            mItems.Remove(mItems[e.Position]);
            adapter.NotifyDataSetChanged();
            string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(mItems, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fullPath, jsonoutput);
        }

        void TextViewdemi_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(BrowsingScreen1Activity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }


        void ButtonExplain_Click(object sender, EventArgs e)
        {
            var explainintent = new Intent(this, typeof(explainScreen));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(explainintent);
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
        }



    }
}
