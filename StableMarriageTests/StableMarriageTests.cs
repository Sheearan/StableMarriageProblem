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

        [TestMethod]
        public void ABreakupShouldResultInNewProposals()
        {
            Buyer b1 = new Buyer();
            Buyer b2 = new Buyer();
            Seller s1 = new Seller();
            Seller s2 = new Seller();
            List<Buyer> buyers = new List<Buyer> { b1, b2 };
            List<Seller> sellers = new List<Seller> { s1, s2 };
            b1.PreferredSellers = new List<Seller> { s2, s1 };
            b2.PreferredSellers = new List<Seller> { s2, s1 };
            s1.PreferredBuyers = new List<Buyer> { b1, b2 };
            s2.PreferredBuyers = new List<Buyer> { b1, b2 };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();

            Assert.AreEqual(s2, b1.RecommendedSeller);
            Assert.AreEqual(s1, b2.RecommendedSeller);
            Assert.AreEqual(b1, s2.RecommendedBuyer);
            Assert.AreEqual(b2, s1.RecommendedBuyer);
        }
    }

    // NOTE: I don't check for whether the inputs are valid (i.e., whether the preference lists actually contain exactly the set of buyers/sellers in the other list)
}
