using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.D1D2.HTTP.Helpers;
using MentoringD1D2.HTTP.Diagnostics;

namespace Mentoring.D1D2.HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            int level = Convert.ToInt32(args[3]);
            bool isDomain = Convert.ToBoolean(args[4]);
            if (String.IsNullOrEmpty(args[0]))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, "Please input directory");
            }

            if (String.IsNullOrEmpty(args[1]))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, "Please input uri");
            }
            HttpHelper httpHelper = new HttpHelper(args[0], args[2]??String.Empty, level, isDomain);
            httpHelper.DownloadSource(args[1]);
            Console.ReadKey();
        }
    }
}
