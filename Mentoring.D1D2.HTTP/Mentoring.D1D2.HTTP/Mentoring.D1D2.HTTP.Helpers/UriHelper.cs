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
        private const string IsAbsoluteUrlPattern = @"^https?://[\w\W]+";

        /// <summary>
        /// Validate if uri ia absolute or not.
        /// </summary>
        /// <param name="uri">The input uri.</param>
        /// <returns>Returns true if the uri is absolute, false - if no. </returns>
        public static bool IsAbsoluteUri(this string uri)
        {
            var absoluteUrlRegex = new Regex(IsAbsoluteUrlPattern);
            return absoluteUrlRegex.IsMatch(uri);
        }
        
    }
}
