using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PROG301_MVC_Currency.ViewModels
{
    /// <summary>
    /// Base class for view models implementing the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the specified property.
        /// </summary>
        /// <param name="name">The name of the property that changed. If not provided, the calling member's name will be used.</param>
        protected void RaisePropertyChangedEvent([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
