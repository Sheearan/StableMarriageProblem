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

        [TestMethod]
        public void RealTestCase()
        {
            Buyer b1 = new Buyer();
            Buyer b2 = new Buyer();
            Buyer b3 = new Buyer();
            Buyer b4 = new Buyer();
            Buyer b5 = new Buyer();
            Buyer b6 = new Buyer();
            Buyer b7 = new Buyer();
            List<Buyer> buyers = new List<Buyer> { b1, b2, b3, b4, b5, b6, b7 };

            Seller A = new Seller();
            Seller B = new Seller();
            Seller C = new Seller();
            Seller D = new Seller();
            Seller E = new Seller();
            Seller F = new Seller();
            Seller G = new Seller();
            Seller H = new Seller();
            Seller I = new Seller();
            Seller J = new Seller();
            Seller K = new Seller();
            Seller L = new Seller();
            Seller M = new Seller();
            Seller N = new Seller();
            Seller O = new Seller();
            List<Seller> sellers = new List<Seller> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O };

            b1.DesiredNumberOfSellers = 1;
            b2.DesiredNumberOfSellers = 2;
            b3.DesiredNumberOfSellers = 3;
            b4.DesiredNumberOfSellers = 3;
            b5.DesiredNumberOfSellers = 2;
            b6.DesiredNumberOfSellers = 3;
            b7.DesiredNumberOfSellers = 1;

            b1.PreferredSellers = new List<Seller> { B, O, L, D, F, A, C, I, N, G, M, E, H, J, K };
            b2.PreferredSellers = new List<Seller> { H, A, N, D, L, I, K, E, B, O, G, C, F, J, M };
            b3.PreferredSellers = new List<Seller> { B, I, F, O, C, A, L, E, D, G, H, J, K, M, N };
            b4.PreferredSellers = new List<Seller> { C, O, M, I, N, G, L, E, D, J, A, B, F, H, K };
            b5.PreferredSellers = new List<Seller> { F, L, A, M, B, E, I, N, G, J, O, C, K, D, H };
            b6.PreferredSellers = new List<Seller> { M, A, C, H, I, N, E, D, F, O, L, K, B, G, J };
            b7.PreferredSellers = new List<Seller> { B, E, H, O, L, D, I, N, G, J, A, M, C, F, K };

            A.PreferredBuyers = new List<Buyer> { b4, b5, b3, b7, b1, b2, b6};
            B.PreferredBuyers = new List<Buyer> { b1, b5, b4, b3, b7, b2, b6 };
            C.PreferredBuyers = new List<Buyer> { b1, b2, b4, b3, b5, b7, b6 };
            D.PreferredBuyers = new List<Buyer> { b7, b2, b3, b1, b5, b6, b4 };
            E.PreferredBuyers = new List<Buyer> { b7, b2, b5, b4, b1, b6, b3 };
            F.PreferredBuyers = new List<Buyer> { b1, b7, b5, b3, b6, b2, b4 };
            G.PreferredBuyers = new List<Buyer> { b5, b2, b4, b3, b7, b1, b6 };
            H.PreferredBuyers = new List<Buyer> { b1, b4, b3, b7, b5, b2, b6 };
            I.PreferredBuyers = new List<Buyer> { b6, b2, b4, b7, b1, b5, b3 };
            J.PreferredBuyers = new List<Buyer> { b7, b3, b4, b1, b6, b2, b5 };
            K.PreferredBuyers = new List<Buyer> { b3, b2, b7, b1, b4, b5, b6 };
            L.PreferredBuyers = new List<Buyer> { b1, b2, b5, b7, b6, b4, b3 };
            M.PreferredBuyers = new List<Buyer> { b1, b7, b3, b5, b6, b4, b2 };
            N.PreferredBuyers = new List<Buyer> { b1, b7, b3, b5, b2, b4, b6 };
            O.PreferredBuyers = new List<Buyer> { b7, b2, b1, b6, b3, b5, b4 };

            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();

            Assert.AreEqual(1, b1.RecommendedSellers.Count);
            Assert.AreEqual(2, b2.RecommendedSellers.Count);
            Assert.AreEqual(3, b3.RecommendedSellers.Count);
            Assert.AreEqual(3, b4.RecommendedSellers.Count);
            Assert.AreEqual(2, b5.RecommendedSellers.Count);
            Assert.AreEqual(3, b6.RecommendedSellers.Count);
            Assert.AreEqual(1, b7.RecommendedSellers.Count);

            Assert.AreEqual(B, b1.RecommendedSellers[0]);
            Assert.AreEqual(D, b2.RecommendedSellers[0]);
            Assert.AreEqual(N, b2.RecommendedSellers[1]);
            Assert.AreEqual(K, b3.RecommendedSellers[0]);
            Assert.AreEqual(J, b3.RecommendedSellers[1]);
            Assert.AreEqual(H, b3.RecommendedSellers[2]);
            Assert.AreEqual(A, b4.RecommendedSellers[0]);
            Assert.AreEqual(G, b4.RecommendedSellers[1]);
            Assert.AreEqual(C, b4.RecommendedSellers[2]);
            Assert.AreEqual(L, b5.RecommendedSellers[0]);
            Assert.AreEqual(F, b5.RecommendedSellers[1]);
            Assert.AreEqual(O, b6.RecommendedSellers[0]);
            Assert.AreEqual(I, b6.RecommendedSellers[1]);
            Assert.AreEqual(M, b6.RecommendedSellers[2]);
            Assert.AreEqual(E, b7.RecommendedSellers[0]);

            Assert.AreEqual(b4, A.RecommendedBuyer);
            Assert.AreEqual(b1, B.RecommendedBuyer);
            Assert.AreEqual(b4, C.RecommendedBuyer);
            Assert.AreEqual(b2, D.RecommendedBuyer);
            Assert.AreEqual(b7, E.RecommendedBuyer);
            Assert.AreEqual(b5, F.RecommendedBuyer);
            Assert.AreEqual(b4, G.RecommendedBuyer);
            Assert.AreEqual(b3, H.RecommendedBuyer);
            Assert.AreEqual(b6, I.RecommendedBuyer);
            Assert.AreEqual(b3, J.RecommendedBuyer);
            Assert.AreEqual(b3, K.RecommendedBuyer);
            Assert.AreEqual(b5, L.RecommendedBuyer);
            Assert.AreEqual(b6, M.RecommendedBuyer);
            Assert.AreEqual(b2, N.RecommendedBuyer);
            Assert.AreEqual(b6, O.RecommendedBuyer);
        }
    }
}
