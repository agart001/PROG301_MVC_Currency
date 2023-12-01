using PROG301_MVC_Currency.Interfaces;
using System.Collections;
using static PROG301_MVC_Currency.Statics.Repos.CurRep;

namespace PROG301_MVC_Currency.Utilities
{
    public static class RandUtils
    {
        public static Random Rand {  get { return new Random(); } }

        public static T GetRandIndex<T>(IEnumerable<T> enumerable) =>
            enumerable.ElementAt(Rand.Next(0, enumerable.Count()));

        public static List<ICoin> GetRandCoinList(Type t)
        {
            List<ICoin> coins = new List<ICoin>();
            List<Type> types = CoinValsByType(t).Select(x => x.GetType()).ToList();

            foreach (var type in types) 
            {
                int numcoins = Rand.Next(0, 10);
                List<ICoin> addedcoins = new List<ICoin>();
                for (int i = 0; i < numcoins; i++)
                {
                    ICoin c = (ICoin)Activator.CreateInstance(type);
                    addedcoins.Add(c);
                }

                coins.AddRange(addedcoins);
            }

            return coins;
        }
    }
}
