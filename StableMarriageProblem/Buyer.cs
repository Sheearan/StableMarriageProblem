using System;
using System.Collections.Generic;

namespace StableMarriageProblem
{
    public class Buyer
    {
        public Seller RecommendedSeller { get; set; }
        public List<Seller> PreferredSellers { get; set; }

        private int preferencePositionOfCurrentRecommendation = -1;

        internal void Propose()
        {
            throw new NotImplementedException();
        }

        internal bool Propose(Seller seller)
        {
            int indexOfNewRecommendedSeller = EvaluateProposal(seller);
            if (indexOfNewRecommendedSeller != preferencePositionOfCurrentRecommendation)
            {
                AcceptProposal(indexOfNewRecommendedSeller);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int EvaluateProposal(Seller seller)
        {
            if (RecommendedSeller == null)
            {
                return PreferredSellers.FindIndex((Seller s) => { return s == seller; });
            }

            for (int i=0; i < preferencePositionOfCurrentRecommendation; i++)
            {
                if (PreferredSellers[i] == seller)
                {
                    return i;
                }
            }

            return preferencePositionOfCurrentRecommendation;
        }

        private void AcceptProposal(int indexOfNewRecommendation)
        {
            if (RecommendedSeller != null)
            {
                RecommendedSeller.RecommendedBuyer = null;
            }

            preferencePositionOfCurrentRecommendation = indexOfNewRecommendation;
            RecommendedSeller = PreferredSellers[indexOfNewRecommendation];
            RecommendedSeller.RecommendedBuyer = this;
        }
    }
}
