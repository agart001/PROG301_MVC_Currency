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


        /// <summary>
        /// Gets a type by its name from the currently loaded assemblies.
        /// </summary>
        /// <param name="name">The name of the type to retrieve.</param>
        /// <returns>The Type object representing the specified type.</returns>
        /// <exception cref="ArgumentException">Thrown if no type with the specified name is found.</exception>
        public static Type TypeByName(string name) =>
            AppDomain.CurrentDomain.GetAssemblies()
                      .SelectMany(a => a.GetTypes()).Where(t => t.Name == name)
                          .FirstOrDefault() ?? throw new ArgumentException(nameof(name));
    }
}