using System.Collections.Generic;

namespace StableMarriageProblem
{
    public class Buyer
    {
        public List<Seller> RecommendedSellers
        {
            get
            {
                return _recommendations.GetList();
            }
        }
        public List<Seller> PreferredSellers { get; set; }
        public int DesiredNumberOfSellers { get; set; }
        public string Name { get; set; } // Optional, for printing results

        private RecommendedSellersList _recommendations;

        public Buyer()
        {
            _recommendations = new RecommendedSellersList(this);
        }

        internal bool Propose(Seller seller)
        {
            int indexOfNewRecommendedSeller = EvaluateProposal(seller);
            if (indexOfNewRecommendedSeller != -1)
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
            if (_recommendations.Count < DesiredNumberOfSellers)
            {
                return PreferredSellers.FindIndex((Seller s) => { return s == seller; });
            }

            for (int i=0; i < _recommendations.IndexOfLeastPreferredSeller; i++)
            {
                if (PreferredSellers[i] == seller)
                {
                    return i;
                }
            }

            return -1;
        }

        private void AcceptProposal(int indexOfNewRecommendation)
        {
            if (RecommendedSellers.Count == DesiredNumberOfSellers)
            {
                _recommendations.RemoveLeastPreferredSeller();
            }

            _recommendations.AddSeller(indexOfNewRecommendation);
        }
    }
}
