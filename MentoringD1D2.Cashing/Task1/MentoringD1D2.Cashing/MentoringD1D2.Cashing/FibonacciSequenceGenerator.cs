using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.Cashing
{
    public static class FibonacciSequenceGenerator
    {
		/// <summary>
		/// Generate fibonacci sequence based on <param name="sequenceLenght"></param>.
		/// </summary>
		/// <param name="sequenceLenght">The number of elements in generated sequence.</param>
		/// <returns>The fibonacci sequence consits of <param name="sequenceLenght"></param> elements.</returns>
	    public static IEnumerable<int> GenerateSequence(int sequenceLenght)
	    {
			if (sequenceLenght <= 0)
				throw new ArgumentOutOfRangeException($"{nameof(sequenceLenght)} : {sequenceLenght}");

			var firstElement = 0;
			var secondElement = 1;

		    if (sequenceLenght == 1)
		    {
		        yield return firstElement;
                yield break;
		    }

		    yield return firstElement;
            yield return secondElement;

            for (var i = 2; i < sequenceLenght; i++)
		    {
                int current = firstElement + secondElement;
                yield return current;
                
                firstElement = secondElement;
                secondElement = current;
            }
	    }
    }
}
