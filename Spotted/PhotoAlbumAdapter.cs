using System;
using Android.Views;
using Android.Support.V7.Widget;

namespace Spotted {
    public class PhotoAlbumAdapter : RecyclerView.Adapter {
        public PhotoAlbum mPhotoAlbum;
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum) {
            mPhotoAlbum = photoAlbum;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType) {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.PhotoCardView, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            vh.Caption.Text = mPhotoAlbum[position].Caption;
            
        }

        public override int ItemCount {
            get { return mPhotoAlbum.NumPhotos; }
        }
    }
}