using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace Spotted
{
    // Photo: contains image resource ID and caption:
    public class Publication
    {
        // Photo ID for this photo:
        public int mPublicationID;

        // Caption text for this photo:
        public string mContent;

        // Return the ID of the photo:
        public int PublicationID
        {
            get { return mPublicationID; }
        }

        // Return the Caption of the photo:
        public string Content
        {
            get { return mContent; }
        }
    }

    // Photo album: holds image resource IDs and caption:
    public class PublicationContainer
    {
        // Built-in photo collection - this could be replaced with
        // a photo database:

        static Publication[] mBuiltInPublications = {
            new Publication { mPublicationID = 1, mContent = "Lorem ipsum dolor sit amet. Consectetur adipiscing elit." },
            new Publication { mPublicationID = 2, mContent = "LOREM IPSUM DOLOR SIT AMET. CONSECTETUR ADIPISCING ELIT."},
            new Publication { mPublicationID = 2, mContent = "LOREM IPSUM DOLOR SIT AMET. CONSECTETUR ADIPISCING ELIT."},
            new Publication { mPublicationID = 2, mContent = "LOREM IPSUM DOLOR SIT AMET. CONSECTETUR ADIPISCING ELIT."}
        };

        // Array of photos that make up the album:
        private Publication[] mPublications;

        // Random number generator for shuffling the photos:
        Random mRandom;

        // Create an instance copy of the built-in photo list and
        // create the random number generator:
        public PublicationContainer()
        {
            mPublications = mBuiltInPublications;
            mRandom = new Random();
        }

        // Return the number of photos in the photo album:
        public int NumPublications
        {
            get { return mPublications.Length; }
        }

        // Indexer (read only) for accessing a photo:
        public Publication this[int i]
        {
            get { return mPublications[i]; }
        }

        // Pick a random photo and swap it with the top:
        public int RandomSwap()
        {
            // Save the photo at the top:
            Publication tmpPublication = mPublications[0];

            // Generate a next random index between 1 and 
            // Length (noninclusive):
            int rnd = mRandom.Next(1, mPublications.Length);

            // Exchange top photo with randomly-chosen photo:
            mPublications[0] = mPublications[rnd];
            mPublications[rnd] = tmpPublication;

            // Return the index of which photo was swapped with the top:
            return rnd;
        }

        // Shuffle the order of the photos:
        public void Shuffle()
        {
            // Use the Fisher-Yates shuffle algorithm:
            for (int idx = 0; idx < mPublications.Length; ++idx)
            {
                // Save the photo at idx:
                Publication tmpPhoto = mPublications[idx];

                // Generate a next random index between idx (inclusive) and 
                // Length (noninclusive):
                int rnd = mRandom.Next(idx, mPublications.Length);

                // Exchange photo at idx with randomly-chosen (later) photo:
                mPublications[idx] = mPublications[rnd];
                mPublications[rnd] = tmpPhoto;
            }
        }
    }
}