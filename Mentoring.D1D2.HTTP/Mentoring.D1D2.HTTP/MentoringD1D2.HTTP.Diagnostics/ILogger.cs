using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.HTTP.Diagnostics
{
    public interface ILogger
    {
        void LogMessage(LogMessageType messageType, string message);
    }
}
