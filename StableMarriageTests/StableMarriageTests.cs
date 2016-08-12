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
            b.DesiredNumberOfSellers = 1;
            b.PreferredSellers = new List<Seller> { s };
            s.PreferredBuyers = new List<Buyer> { b };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();
            Assert.AreEqual(1, b.RecommendedSellers.Count);
            Assert.AreEqual(s, b.RecommendedSellers[0]);
            Assert.AreEqual(b, s.RecommendedBuyer);
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
            b1.DesiredNumberOfSellers = 1;
            b1.PreferredSellers = new List<Seller> { s2, s1 };
            b2.DesiredNumberOfSellers = 1;
            b2.PreferredSellers = new List<Seller> { s2, s1 };
            s1.PreferredBuyers = new List<Buyer> { b1, b2 };
            s2.PreferredBuyers = new List<Buyer> { b1, b2 };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();

            Assert.AreEqual(1, b1.RecommendedSellers.Count);
            Assert.AreEqual(s2, b1.RecommendedSellers[0]);
            Assert.AreEqual(1, b2.RecommendedSellers.Count);
            Assert.AreEqual(s1, b2.RecommendedSellers[0]);
            Assert.AreEqual(b1, s2.RecommendedBuyer);
            Assert.AreEqual(b2, s1.RecommendedBuyer);
        }

        [TestMethod]
        public void ABuyerCanRequestMultipleSellers()
        {
            Buyer b1 = new Buyer();
            Seller s1 = new Seller();
            Seller s2 = new Seller();
            List<Buyer> buyers = new List<Buyer> { b1 };
            List<Seller> sellers = new List<Seller> { s1, s2 };
            b1.DesiredNumberOfSellers = 2;
            b1.PreferredSellers = new List<Seller> { s2, s1 };
            s1.PreferredBuyers = new List<Buyer> { b1 };
            s2.PreferredBuyers = new List<Buyer> { b1 };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();

            Assert.AreEqual(2, b1.RecommendedSellers.Count);
            Assert.AreEqual(s1, b1.RecommendedSellers[0]);
            Assert.AreEqual(s2, b1.RecommendedSellers[1]);
            Assert.AreEqual(b1, s2.RecommendedBuyer);
            Assert.AreEqual(b1, s1.RecommendedBuyer);
        }
    }

    // NOTE: I don't check for whether the inputs are valid (i.e., whether the preference lists actually contain exactly the set of buyers/sellers in the other list and whether the number of buyer-slots and sellers match)
}
