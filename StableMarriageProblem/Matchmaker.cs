using System.Collections.Generic;

namespace StableMarriageProblem
{
    public class Matchmaker
    {
        private List<Buyer> _buyers;
        private List<Seller> _sellers;

        public Matchmaker(List<Buyer> buyers, List<Seller> sellers)
        {
            _buyers = buyers;
            _sellers = sellers;
        }

        public void Match()
        {
            foreach(Seller currentSeller in _sellers)
            {
                currentSeller.SelectBuyer();
            }
        }
    }
}
