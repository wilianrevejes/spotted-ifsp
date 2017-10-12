using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Spotted {
    public class PhotoViewHolder : RecyclerView.ViewHolder {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public PhotoViewHolder(View itemView) : base(itemView) {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}