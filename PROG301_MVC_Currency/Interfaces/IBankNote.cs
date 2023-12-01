
namespace PROG301_MVC_Currency.Interfaces
{
    /// <summary>
    /// Represents an interface for defining a banknote with a year of issue.
    /// </summary>
    public interface IBankNote
    {
        /// <summary>
        /// Gets or sets the year of issue of the banknote.
        /// </summary>
        public int Year { get; set; }
    }
}
