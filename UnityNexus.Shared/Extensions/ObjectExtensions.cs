using System.Runtime.CompilerServices;

namespace UnityNexus.Shared.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null, otherwise returns the <paramref name="argument"/>.
        /// </summary>
        /// <param name="argument">The reference type argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <returns>The <paramref name="argument"/>, if it is not null.</returns>
        public static T IfNotNull<T>(
            this T? argument,
            [CallerArgumentExpression("argument")] string? paramName = null
        ) where T : class
        {
            ArgumentNullException.ThrowIfNull(argument, paramName);
            return argument;
        }
    }
}
