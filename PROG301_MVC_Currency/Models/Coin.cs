using PROG301_MVC_Currency.Interfaces;
using static PROG301_MVC_Currency.Statics.Currency;

namespace PROG301_MVC_Currency.Models
{
    /// <summary>
    /// Represents a coin with a value, a name, and a year of issue.
    /// </summary>
    public class Coin : ICoin
    {
        /// <summary>
        /// Gets or sets the id of the coin.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the XAU value of the coin.
        /// </summary>
        public decimal XAUValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the coin.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the coin.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the year of issue of the coin.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the about information of the coin.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class.
        /// </summary>
        public Coin()
        {
            ID = Guid.NewGuid();
            Name = String.Empty;
            Desc = String.Empty;
            // Default constructor for the coin.
        }

        /// <summary>
        /// Sets the description of the coin.
        /// </summary>
        /// <param name="region">The origin region of the coin.</param>
        /// <param name="symbol">The currency symbol of the coin's region.</param>
        /// <param name="mintName">The name of the coin's mint based on its symbol.</param>
        public void SetDesc(string region, string symbol, string mintName)
        {
            Desc = 
            $"{region} {Name} is from {Year}. " +
            $"It is worth {symbol}{Value}. " +
            $"It was made in {mintName}";
        }

        public string About() => Desc;

        public static string GetMintNameFromMark(Type caller, Enum mark)
        {
            Dictionary<Enum, string> mintMarkDict = CurMintMarkDict[caller];
            if(mintMarkDict == null) { throw new Exception("The mint mark dictionary is null.");}

            string mintName = mintMarkDict[mark];
            if(mintName == null) { throw new Exception("The mint name is null.");}

            return mintName;
        }
    }
}
