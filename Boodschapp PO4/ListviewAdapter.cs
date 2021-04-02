using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Boodschapp_PO4
{
    class ListviewAdapter : BaseAdapter<string>
    {

        private List    <string> mItems;
        private Context mContext;

        public ListviewAdapter(Context context, List<string> items)
        {
            mItems      = items;
            mContext    = context;
        }

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position] => mItems[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.GrocerylistRow, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.txt1);
            txt1.Text = mItems[position];

            //TextView txt2 = row.FindViewById<TextView>(Resource.Id.txt2);
            //txt2.Text = mItems[position].second;





            return row;
        }
    }
}