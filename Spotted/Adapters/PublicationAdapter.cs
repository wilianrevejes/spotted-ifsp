using Android.Views;
using Android.Support.V7.Widget;

namespace Spotted {
    public class PublicationAdapter : RecyclerView.Adapter {

        public PublicationContainer mPublicationContainer;

        public PublicationAdapter(PublicationContainer publicationContainer) {
            mPublicationContainer = publicationContainer;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PublicationCardView, parent, false);
            PublicationViewHolder vh = new PublicationViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            PublicationViewHolder vh = holder as PublicationViewHolder;
            vh.content.Text = mPublicationContainer[position].Content;

        }

        public override int ItemCount {
            get { return mPublicationContainer.NumPublications; }
        }
    }
}