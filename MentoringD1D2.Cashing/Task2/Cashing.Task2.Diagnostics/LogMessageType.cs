using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashing.Task2.Diagnostics
{
    /// <summary>
	/// The available message types to log.
	/// </summary>
	public enum LogMessageType
    {
        /// <summary> Debugging Message.</summary>
        Debug,

        /// <summary> Informational Message.</summary>
        Info,

        /// <summary> Warning Message.</summary>
        Warn,

        /// <summary>Non-Fatal Error.</summary>
        Error,

        /// <summary>Fatal Error.</summary>
        Fatal
    }
}
