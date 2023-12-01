using PROG301_MVC_Currency.Interfaces;
using PROG301_MVC_Currency.Models;
using PROG301_MVC_Currency.Models.UKCoins;
using PROG301_MVC_Currency.Models.USCoins;
using PROG301_MVC_Currency.Repos;
using static PROG301_MVC_Currency.Utilities.TypeUtils;

namespace PROG301_MVC_Currency.Statics
{
    /// <summary>
    /// This class represents a utility for managing different repositories of currency-related data.
    /// </summary>
    public static class Repos
    {
        /// <summary>
        /// This struct contains information and methods related to currency repositories.
        /// </summary>
        public struct CurRep
        {
            /// <summary>
            /// A dictionary that maps currency repository types to their respective lists of ICoin objects.
            /// </summary>
            public static Dictionary<Type, List<ICoin>> RepoCoinDict = new Dictionary<Type, List<ICoin>>()
            {
                {typeof(USCurrencyRepo), GetDerivedCoins<USCoin>()},
                {typeof(UKCurrencyRepo), GetDerivedCoins<UKCoin>()}
            };

            /// <summary>
            /// Gets a list of instances of types derived from a specified base type.
            /// </summary>
            /// <typeparam name="T">The base type from which derived types are obtained.</typeparam>
            /// <returns>A list of instances of types derived from <typeparamref name="T"/>.</returns>
            /// <exception cref="Exception">Thrown when the creation of an instance of a derived type fails.</exception>
            public static List<ICoin> GetDerivedCoins<T>()
            {
                List<ICoin> coins = new List<ICoin>();
                Type[] derivedTypes = GetSubclasses<T>();

                foreach (Type type in derivedTypes)
                {
                    ICoin coin = (ICoin)Activator.CreateInstance(type);

                    if (coin is null) { throw new Exception("Failed to create instance of derived coin."); }

                    coins.Add(coin);
                }

                return coins;
            }


            /// <summary>
            /// Returns a list of coin values by the specified caller's type.
            /// </summary>
            /// <param name="caller">The Type of the CurrencyRepo requesting coin values.</param>
            /// <returns>A list of ICoin objects with values based on the caller's type.</returns>
            public static List<ICoin> CoinValsByType(Type t)
            {;
                List<Type> Types = new List<Type>(RepoCoinDict.Keys);

                // Check if the caller's type is one of the supported currency repository types.
                if (Types.Contains(t))
                {
                    // If so, return the list of ICoin objects associated with the caller's type.
                    return RepoCoinDict[t];
                }
                else
                {
                    // Otherwise, throw an exception.
                    throw new Exception("Invalid caller type.");
                }
            }
        }
    }
}
