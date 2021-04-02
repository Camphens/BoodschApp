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
    // Adapter for the categories
    //----------------------------------------------------------------------
    public class BrowsingCategoryAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int>  ItemClick;
        public ProductList              mProductList;
        int radius;
        int value;
        int value2;


        public BrowsingCategoryAdapter(ProductList productList)
        {
            mProductList            = productList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView           = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CategoryCardView, parent, false);
            BrowsingViewHolder vh   = new BrowsingViewHolder(itemView, OnClick);
            //return vh;

            //value   = parent.Height / 4;
            //value2  = parent.Width / 4;
            //if (value < value2)
            //{
            //    itemView.LayoutParameters.Height = value2;
            //}

            //else
            //{
            //    itemView.LayoutParameters.Height = value;
            //}
            itemView.LayoutParameters.Height = parent.Height / 4;

            radius = itemView.LayoutParameters.Height;
            value = radius/2;// - (radius / 3);

            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BrowsingViewHolder vh   = holder as BrowsingViewHolder;
            vh.Category.Text        = mProductList[position].category.ToString();
            vh.BrowseImage.SetImageResource(mProductList[position].image);
            //vh.CategoryView.Radius = radius / 2.2f;


            if (mProductList[position].category.ToString() == "Eten")
            {   vh.CategoryView.SetCardBackgroundColor(Color.Rgb(214, 229, 255));
                vh.BrowseImage.LayoutParameters.Height = (value - (value/4));
                vh.BrowseImage.LayoutParameters.Width = (int)((value - (value / 4)) * 1.6);
            }

            if (mProductList[position].category.ToString() == "Drinken")
            {   vh.CategoryView.SetCardBackgroundColor(Color.Rgb(224, 235, 255));
                vh.BrowseImage.LayoutParameters.Height = (value + (value/4));
                vh.BrowseImage.LayoutParameters.Width = (int)((value + (value / 4)) * 1.6);
            }

            if (mProductList[position].category.ToString() == "Recepten")
            {   vh.CategoryView.SetCardBackgroundColor(Color.Rgb(224, 235, 255));
                vh.BrowseImage.LayoutParameters.Height = value;
                vh.BrowseImage.LayoutParameters.Width = (int)(value * 2.03);
            }

            if (mProductList[position].category.ToString() == "Nonfood")
            {   vh.CategoryView.SetCardBackgroundColor(Color.Rgb(214, 229, 255));
                vh.BrowseImage.LayoutParameters.Height = (radius - (radius/5));
                vh.BrowseImage.LayoutParameters.Width = (int)((radius - (radius / 5)) * 0.76);
            }


            //vh.BrowseImage.LayoutParameters.Height = radius - (radius / 3);
            //vh.BrowseImage.LayoutParameters.Width = value;









            //vh.Group.Text         = mProductList[position].GroupName;
            //vh.Category.Typeface    = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/BubbleboddyNeue-BoldTrial.ttf");
        }

        public override int ItemCount
        {
            get { return mProductList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }
}