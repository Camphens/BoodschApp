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
    // Adapter for the actual products
    //----------------------------------------------------------------------
    public class BrowsingProductAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int>  ItemClick;
        public ProductList              mProductList;
        int                             row_index;
        List<CardView>                  cardviewList = new List<CardView>();
        List<int>                       ProductIDSelected = new List<int>();


        public BrowsingProductAdapter(ProductList productlist)
        {
            mProductList            = productlist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView           = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ProductCardView, parent, false);
            BrowsingViewHolder vh   = new BrowsingViewHolder(itemView, OnClick);
            itemView.LayoutParameters.Height = parent.Height / 8;
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BrowsingViewHolder vh   = holder as BrowsingViewHolder;
            //vh.Category.Text      = mProductList[position].category.ToString();
            //vh.Group.Text         = mProductList[position].group.ToString();
            vh.Name.Text            = mProductList[position].name.ToString();
            //vh.Name.Typeface        = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/BubbleboddyNeue-BoldTrial.ttf");
            vh.Name.SetTextSize(Android.Util.ComplexUnitType.FractionParent, 11f);
            int counter             = 0;

            //cardviewList.Add(vh.CardViewer);

            for (int i = 0; i <ProductIDSelected.Count; i++)
            {
                if (ProductIDSelected[i] == position)
                {
                    counter += 1;
                    //vh.CardViewer.SetCardBackgroundColor(Android.Graphics.Color.LightGreen);
                }
            }
            
            if (counter == 1)
            {
                vh.CardViewer.SetCardBackgroundColor(Android.Graphics.Color.LightGreen);
            }
            else
            {
                vh.CardViewer.SetCardBackgroundColor(Android.Graphics.Color.White);
            }

        }

        public override int ItemCount
        {
            get { return mProductList.NumProducts; }
        }

        void OnClick(int position)
        {
            row_index = 0;

            for (int i = 0; i < ProductIDSelected.Count; i++)
            {
                if (ProductIDSelected[i] != position)
                {
                    row_index += 1;   
                }
            }

            if (row_index == ProductIDSelected.Count)
            {
                ProductIDSelected.Add(position);
            }

            else
            {
                ProductIDSelected.Remove(position);
            }

            NotifyDataSetChanged();
            

            if (ItemClick != null) ItemClick(this, position);
            
        }


    }
}