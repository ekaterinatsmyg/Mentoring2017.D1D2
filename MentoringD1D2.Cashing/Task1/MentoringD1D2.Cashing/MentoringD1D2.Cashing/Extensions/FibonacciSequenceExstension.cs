using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.Cashing.Extensions
{
    public static class FibonacciSequenceExstension
    {
        public static string ToCustomString(this IEnumerable<int> sequence)
        {
            return string.Join(",", sequence.Select(i => i.ToString()).ToArray());
        }
    }
}
