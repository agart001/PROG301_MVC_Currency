
namespace PROG301_MVC_Currency.Interfaces
{
    /// <summary>
    /// Represents an interface for defining a coin with a year of issue.
    /// </summary>
    public interface ICoin : ICurrency
    {
        /// <summary>
        /// Gets or sets the year of issue of the coin.
        /// </summary>
        public int Year { get; set; }
    }
}
