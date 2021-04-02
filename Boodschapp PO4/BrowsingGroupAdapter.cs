using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Boodschapp_PO4
{
    //----------------------------------------------------------------------
    // Adapter for the groups
    //----------------------------------------------------------------------
    public class BrowsingGroupAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public ProductList mGroupList;


        public BrowsingGroupAdapter(ProductList grouplist)
        {
            mGroupList = grouplist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GroupCardView, parent, false);
            BrowsingViewHolder vh = new BrowsingViewHolder(itemView, OnClick);
            itemView.LayoutParameters.Height = parent.Height / 8;
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BrowsingViewHolder vh   = holder as BrowsingViewHolder;
            //vh.Category.Text      = mGroupList[position].CategoryName;
            vh.Group.Text           = mGroupList[position].group.ToString();
            //vh.Group.Typeface       = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/BubbleboddyNeue-BoldTrial.ttf");
            vh.Group.SetTextSize(Android.Util.ComplexUnitType.FractionParent, 14f);
        }

        public override int ItemCount
        {
            get { return mGroupList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }
}