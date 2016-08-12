using System.Collections.Generic;

namespace StableMarriageProblem
{
    public class Seller
    {
        public Buyer RecommendedBuyer { get; set; }
        public List<Buyer> PreferredBuyers { get; set; }
        public string Name { get; set; } // Optional, for printing results


        internal void SelectBuyer()
        {
            for (int i = 0; i < PreferredBuyers.Count; i++)
            {
                bool response = PreferredBuyers[i].Propose(this);
                if (RecommendedBuyer != null)
                {
                    return;
                }
            }
        }
    }
}
