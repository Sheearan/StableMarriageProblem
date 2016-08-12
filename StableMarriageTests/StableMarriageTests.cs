using Microsoft.VisualStudio.TestTools.UnitTesting;
using StableMarriageProblem;
using System.Collections.Generic;

namespace StableMarriageTests
{
    [TestClass]
    public class StableMarriageTests
    {
        [TestMethod]
        public void WithOneBuyerAndOneSellerTheyShouldMatch()
        {
            Buyer b = new Buyer();
            Seller s = new Seller();
            List<Buyer> buyers = new List<Buyer> { b };
            List<Seller> sellers = new List<Seller> { s };
            b.PreferredSellers = new List<Seller> { s };
            s.PreferredBuyers = new List<Buyer> { b };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();
            Assert.AreEqual(s, b.RecommendedSeller, "Buyer should have s as the recommended seller");
            Assert.AreEqual(b, s.RecommendedBuyer, "Seller should have b as the recommended buyer");
        }
    }

    // NOTE: I don't check for whether the inputs are valid (i.e., whether the preference lists actually contain exactly the set of buyers/sellers in the other list)
}
