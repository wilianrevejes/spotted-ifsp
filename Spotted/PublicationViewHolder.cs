using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Spotted {
    public class PublicationViewHolder : RecyclerView.ViewHolder {
        public TextView content { get; private set; }
        
        public PublicationViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            content = itemView.FindViewById<TextView>(Resource.Id.content);
        }
    }
}