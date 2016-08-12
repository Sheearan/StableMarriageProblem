using System.Collections.Generic;

namespace StableMarriageProblem
{
    class Program
    {
        public static void Main(string[] args)
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

            A.PreferredBuyers = new List<Buyer> { b4, b5, b3, b7, b1, b2, b6 };
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

            b1.Name = "Buyer 1";
            b2.Name = "Buyer 2";
            b3.Name = "Buyer 3";
            b4.Name = "Buyer 4";
            b5.Name = "Buyer 5";
            b6.Name = "Buyer 6";
            b7.Name = "Buyer 7";

            A.Name = "Seller A";
            B.Name = "Seller B";
            C.Name = "Seller C";
            D.Name = "Seller D";
            E.Name = "Seller E";
            F.Name = "Seller F";
            G.Name = "Seller G";
            H.Name = "Seller H";
            I.Name = "Seller I";
            J.Name = "Seller J";
            K.Name = "Seller K";
            L.Name = "Seller L";
            M.Name = "Seller M";
            N.Name = "Seller N";
            O.Name = "Seller O";


            Matchmaker m = new Matchmaker(buyers, sellers);
            m.Match();

            foreach(Seller sell in sellers)
            {
                System.Console.WriteLine(string.Format("{0} should sell to {1}", sell.Name, sell.RecommendedBuyer.Name));
            }

            System.Console.ReadLine();
        }
    }
}
