
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace Spotted
{
	public class HomeFragment : Fragment{
        Activity view;
        RecyclerView mRecyclerView;
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

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this.view);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new PublicationAdapter(mPublicationContainer);
            mRecyclerView.SetAdapter(mAdapter);

            return view;
		}

	}
}

