using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mentoring.D1D2.HTTP.Helpers
{
    /// <summary>
    /// The entity that provides additional funqtionality for Uri type.
    /// </summary>
    public static class UriHelper
    {
        /// <summary>
        /// The pattern that helps to determine whether the uri absolute or not.
        /// </summary>
        private const string IsAbsoluteUrl = @"^https?://[\w\W]+";

        /// <summary>
        /// The regex that validate if the url is absolute.
        /// </summary>
        private static Regex absoluteUrlRegex = CreateRegEx(IsAbsoluteUrl);

        /// <summary>
        /// Validate if uri ia absolute or not.
        /// </summary>
        /// <param name="uri">The input uri.</param>
        /// <returns>Returns true if the uri is absolute, false - if no. </returns>
        public static bool IsAbsoluteUri(this string uri)
        {
            return absoluteUrlRegex.IsMatch(uri);
        }

        /// <summary>
        /// Create an instance of regex type.
        /// </summary>
        /// <param name="pattern">The pattern of regex.</param>
        /// <returns>An instance of regex type.</returns>
        private static Regex CreateRegEx(string pattern)
        {
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

            return new Regex(pattern, options);
        }
    }
}
