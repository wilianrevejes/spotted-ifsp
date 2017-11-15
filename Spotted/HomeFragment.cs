using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Content;

namespace Spotted
{
	public class HomeFragment : Fragment{
        Activity view;
        RecyclerView mRecyclerView;
        FloatingActionButton fab;
        RecyclerView.LayoutManager mLayoutManager;
        PublicationAdapter mAdapter;
        PublicationContainer mPublicationContainer;

        public HomeFragment(Activity v) {
            view = v;
        }

        public override void OnCreate (Bundle savedInstanceState){
			base.OnCreate (savedInstanceState);
            
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			View view = inflater.Inflate(Resource.Layout.homeLayout, container,false);

            mPublicationContainer = new PublicationContainer();

            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            //Floating action button
            fab.Click += (sender, args) => {
                var NxtAct = new Intent(view.Context, typeof(PublicationActivity));
                StartActivity(NxtAct);
            };


            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this.view);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new PublicationAdapter(mPublicationContainer);
            mRecyclerView.SetAdapter(mAdapter);

            return view;
		}

        public override void OnResume() {
            base.OnResume();

            mPublicationContainer.populatePublications();
            mAdapter.NotifyDataSetChanged();
        }

    }
}

