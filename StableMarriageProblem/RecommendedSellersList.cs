using System.Collections.Generic;

namespace StableMarriageProblem
{
    class RecommendedSellersList
    {
        public int IndexOfLeastPreferredSeller
        {
            get
            {
                if (_preferencePositionOfCurrentRecommendation.Count == 0)
                {
                    return -1;
                }

                return _preferencePositionOfCurrentRecommendation[0];
            }
        }

        public int Count
        {
            get
            {
                return _recommendedSellers.Count;
            }
        }

        private List<Seller> _recommendedSellers = new List<Seller> { };
        private List<int> _preferencePositionOfCurrentRecommendation = new List<int> { };
        private Buyer _buyer;

        private RecommendedSellersList()
        {

        }

        public RecommendedSellersList(Buyer buyer)
        {
            _buyer = buyer;
        }

        internal List<Seller> GetList()
        {
            return _recommendedSellers;
        }

        internal void RemoveLeastPreferredSeller()
        {
            if (_recommendedSellers.Count == 0)
            {
                return;
            }

            _recommendedSellers[0].RecommendedBuyer = null;
            _recommendedSellers.Remove(_recommendedSellers[0]);
            _preferencePositionOfCurrentRecommendation.Remove(_preferencePositionOfCurrentRecommendation[0]);
        }

        internal void AddSeller(int preferenceOrderOfNewRecommendation)
        {
            int positionToInsert;

            for (positionToInsert = 0; positionToInsert < _recommendedSellers.Count; positionToInsert++)
            {
                if (preferenceOrderOfNewRecommendation > _preferencePositionOfCurrentRecommendation[positionToInsert])
                {
                    break;
                }
            }

            _preferencePositionOfCurrentRecommendation.Insert(positionToInsert, preferenceOrderOfNewRecommendation);
            _recommendedSellers.Insert(positionToInsert, _buyer.PreferredSellers[preferenceOrderOfNewRecommendation]);
            _recommendedSellers[positionToInsert].RecommendedBuyer = _buyer; 
        }
    }
}
