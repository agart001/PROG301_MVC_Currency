namespace PROG301_MVC_Currency.Utilities
{
    /// <summary>
    /// Provides utility methods for working with types.
    /// </summary>
    public static class TypeUtils
    {
        /// <summary>
        /// Gets an array of types that are subclasses of a specified base type.
        /// </summary>
        /// <typeparam name="T">The base type from which to retrieve subclasses.</typeparam>
        /// <returns>An array of types that are subclasses of <typeparamref name="T"/>.</returns>
        public static Type[] GetSubclasses<T>() =>
            AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(t => t.IsSubclassOf(typeof(T))).ToArray();
    }
}