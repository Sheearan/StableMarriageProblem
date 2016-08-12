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
            bool isStable = false;

            // Note: this is not the most performant way to handle this, but it is the most expedient to code.
            // If performance becomes an issue, we can revisit it.
            // Depending on team culture and how your team handles stuff like this generally, I would probably add a tech debt item to optimize this
            // Alternately, I'd do it myself before checkin - but the 4-hour time box is causing me to make this performance tradeoff
            while (!isStable)
            {
                isStable = true;
                foreach (Seller currentSeller in _sellers)
                {
                    if (currentSeller.RecommendedBuyer == null)
                    {
                        currentSeller.SelectBuyer();
                        isStable = false;
                    }
                }
            }
        }
    }
}
