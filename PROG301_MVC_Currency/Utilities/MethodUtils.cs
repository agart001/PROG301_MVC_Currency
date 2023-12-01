using System.Reflection;

namespace PROG301_MVC_Currency.Utilities
{
    /// <summary>
    /// A utility class for invoking methods on an instance of a specified type.
    /// </summary>
    public static class MethodUtils
    {
        /// <summary>
        /// Invokes a method on an instance of a specified type and returns the result.
        /// </summary>
        /// <typeparam name="T">The expected return type of the method.</typeparam>
        /// <param name="targetType">The type on which to invoke the method.</param>
        /// <param name="methodName">The name of the method to invoke.</param>
        /// <param name="methodParameters">An array of method parameters to pass to the method.</param>
        /// <returns>The result of invoking the method, cast to the specified return type.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the specified type is not a class or does not have a parameterless constructor.</exception>
        /// <exception cref="MissingMethodException">Thrown when the specified method was not found or is not accessible.</exception>
        /// <exception cref="InvalidCastException">Thrown when the method does not return the expected type.</exception>
        public static T InvokeMethod<T>(Type targetType, string methodName, object[] methodParameters)
        {
            // Check if targetType is a class and has a parameterless constructor
            if (targetType.IsClass && targetType.GetConstructor(Type.EmptyTypes) != null)
            {
                // Create an instance of the target class
                object? targetInstance = Activator.CreateInstance(targetType);

                var methods = targetType.GetMethods();

                // Get the method info
                MethodInfo? methodInfo = methods.Where(m => m.Name == methodName).FirstOrDefault();

                // Check if the method exists and is accessible
                if (methodInfo != null && methodInfo.IsPublic)
                {
                    // Invoke the method and return its result
                    object? result = methodInfo.Invoke(targetInstance, methodParameters);

                    if (result == null)
                    {
                        throw new InvalidOperationException("The method invoke returned null.");
                    }

                    var cast = (T)result;

                    if (cast != null)
                    {
                        return cast;
                    }
                    else
                    {
                        // Handle the case where the result is not of type T
                        throw new InvalidCastException("The method did not return the expected type.");
                    }
                }
                else
                {
                    throw new MissingMethodException("The specified method was not found or is not accessible.");
                }
            }
            else
            {
                throw new InvalidOperationException("The specified type is not a class or does not have a parameterless constructor.");
            }
        }

        /// <summary>
        /// Creates an instance of a specified class type and returns it, cast to the specified generic type.
        /// </summary>
        /// <typeparam name="T">The expected type to cast the created instance to.</typeparam>
        /// <param name="targetType">The type of the class to create an instance of.</param>
        /// <returns>An instance of the specified class type, cast to the specified generic type.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the specified type is not a class or does not have a parameterless constructor.</exception>
        /// <exception cref="InvalidCastException">Thrown when the created instance cannot be cast to the expected generic type.</exception>
        public static T CreateInstance<T>(Type targetType)
        {
            // Check if targetType is a class and has a parameterless constructor
            if (targetType.IsClass && targetType.GetConstructor(Type.EmptyTypes) != null)
            {
                // Create an instance of the target class
                object? targetInstance = Activator.CreateInstance(targetType);

                if (targetInstance == null)
                {
                    throw new InvalidOperationException("The target type could not be created.");
                }

                var cast = (T)targetInstance;

                if (cast != null)
                {
                    return cast;
                }
                else
                {
                    // Handle the case where the result is not of type T
                    throw new InvalidCastException("The created instance cannot be cast to the expected type.");
                }
            }
            else
            {
                throw new InvalidOperationException("The specified type is not a class or does not have a parameterless constructor.");
            }
        }

    }
}
