using PROG301_MVC_Currency.Commands;
using PROG301_MVC_Currency.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace PROG301_MVC_Currency.ViewModels
{
    /// <summary>
    /// ViewModel for managing an enumerable of items.
    /// </summary>
    /// <typeparam name="T">Type of items in the enumerable.</typeparam>
    public class IEnumerableViewModel<T> : BaseViewModel
    {
        private IEnumerable<T> enumerable = null;

        #region Enumerable

        /// <summary>
        /// Gets the enumerable of items.
        /// </summary>
        public IEnumerable<T> Enum
        {
            get
            {
                GetEnum.Execute(null);
                return GetEnum.Result;
            }
        }

        private ReturnCommand<IEnumerable<T>> GetEnum { get; set; }

        private bool getEnum = false;

        private bool CanGetEnum(object parameter) => getEnum;

        private IEnumerable<T> ReturnEnum(object parameter)
        {
            return enumerable;
        }

        #endregion

        #region Count

        /// <summary>
        /// Gets the count of items in the enumerable.
        /// </summary>
        public int Count
        {
            get
            {
                GetCount.Execute(null);
                return GetCount.Result;
            }
        }

        private ReturnCommand<int> GetCount { get; set; }

        private bool getCount = false;

        private bool CanGetCount(object parameter) => getCount;

        private int ReturnCount(object parameter)
        {
            return enumerable.Count();
        }

        #endregion

        #region Content Type

        /// <summary>
        /// Gets the type of the content in the enumerable.
        /// </summary>
        public Type ContentType
        {
            get
            {
                if (enumerable != null)
                {
                    var first = enumerable.FirstOrDefault();
                    GetContentType.Execute(first ?? throw new NullReferenceException(nameof(first)));
                }
                return GetContentType.Result;
            }
        }

        private ReturnCommand<Type> GetContentType { get; set; }

        private bool getContentType = false;

        private bool CanGetContentType(object parameter) => getContentType;

        private Type ReturnContentType(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            return parameter.GetType();
        }

        #endregion

        #region Content Fields

        /// <summary>
        /// Gets the fields and their values of the content in the enumerable.
        /// </summary>
        public Dictionary<string, object> ContentFields
        {
            get
            {
                if (enumerable != null)
                {
                    var first = enumerable.FirstOrDefault();
                    GetContentFields.Execute(first);
                }
                return GetContentFields.Result;
            }
        }

        private ReturnCommand<Dictionary<string, object>> GetContentFields { get; set; }

        private bool getContentFields = false;
        private bool CanGetContentFields(object parameter) => getContentFields;

        private Dictionary<string, object> ReturnContentFields(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            Dictionary<string, object> result = new Dictionary<string, object>();

            Type type = parameter.GetType();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                result[property.Name] = property.GetValue(parameter) ?? throw new NullReferenceException(nameof(parameter));
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableViewModel{T}"/> class.
        /// </summary>
        /// <param name="_enumerable">The enumerable of items.</param>
        /// <param name="_getEnum">Flag indicating whether to retrieve the enumerable.</param>
        /// <param name="_getCount">Flag indicating whether to retrieve the count of items.</param>
        /// <param name="_getContentType">Flag indicating whether to retrieve the content type.</param>
        /// <param name="_getContentFields">Flag indicating whether to retrieve the content fields.</param>
        public IEnumerableViewModel(IEnumerable<T> _enumerable, bool _getEnum, bool _getCount, bool _getContentType, bool _getContentFields)
        {
            enumerable = _enumerable;
            getEnum = _getEnum;
            getCount = _getCount;
            getContentType = _getContentType;
            getContentFields = _getContentFields;

            GetEnum = new ReturnCommand<IEnumerable<T>>(ReturnEnum, CanGetEnum);
            GetCount = new ReturnCommand<int>(ReturnCount, CanGetCount);
            GetContentType = new ReturnCommand<Type>(ReturnContentType, CanGetContentType);
            GetContentFields = new ReturnCommand<Dictionary<string, object>>(ReturnContentFields, CanGetContentFields);
        }
    }
}
