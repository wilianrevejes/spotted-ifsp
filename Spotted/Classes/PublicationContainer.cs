using System;
using System.Collections.Generic;

namespace Spotted {
    
    public class PublicationContainer
    {
        PublicationFactory pf;
        private IList<Publication> mPublications;

        Random mRandom;

        public PublicationContainer()
        {
            pf = new PublicationFactory();
            var response = pf.getAll();
            
            mPublications = response;
            mRandom = new Random();
        }

        public void populatePublications() {
            pf = new PublicationFactory();

            var response = pf.getAll();
            
            mPublications = response;
        }

        // Return the number of photos in the photo album:
        public int NumPublications
        {
            get { return mPublications.Count; }
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
            int rnd = mRandom.Next(1, mPublications.Count);

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
            for (int idx = 0; idx < mPublications.Count; ++idx)
            {
                // Save the photo at idx:
                Publication tmpPhoto = mPublications[idx];

                // Generate a next random index between idx (inclusive) and 
                // Length (noninclusive):
                int rnd = mRandom.Next(idx, mPublications.Count);

                // Exchange photo at idx with randomly-chosen (later) photo:
                mPublications[idx] = mPublications[rnd];
                mPublications[rnd] = tmpPhoto;
            }
        }
    }
}