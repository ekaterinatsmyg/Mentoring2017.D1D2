using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mentoring.D1D2.HTTP.Helpers;
using Mentoring.D1D2.HTTP.Parsers;
using MentoringD1D2.HTTP.Diagnostics;
using Microsoft.Practices.Unity;

namespace Mentoring.D1D2.HTTP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter arguments.");
                return;
            }

            var unityContainer = new UnityContainer();

            ParametrsModel parametrs;
            ParametrsParser.TryParse(args, out parametrs, unityContainer);

            if (parametrs.IsEventLogger)
                unityContainer.RegisterType<ILogger, EventLogger>();

            unityContainer.RegisterType<ILogger, ApplicationLogger>();

            var logger = unityContainer.Resolve<ILogger>();

            if (String.IsNullOrEmpty(parametrs.Directory))
            {
                logger.LogMessage(LogMessageType.Error,
                    "Please input directory. The directory is the necessary parametr.");
                return;
            }

            if (!Directory.Exists(parametrs.Directory))
            {
                logger.LogMessage(LogMessageType.Error, $"The directory {parametrs.Directory} doesn't exist.");
                return;
            }

            if (String.IsNullOrEmpty(parametrs.Uri))
            {
                logger.LogMessage(LogMessageType.Error, "Please input uri.");
                return;
            }
            
            var regex = new Regex(@"^((https?|ftp|file):\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(parametrs.Uri))
            {
                logger.LogMessage(LogMessageType.Error, $"Incorrect uri: {parametrs.Uri}.");
                return;
            }

            var webSourceDownloader = new WebSourceDownloader(parametrs.Directory, parametrs.Extensions,
                parametrs.Level, parametrs.IsDomain, logger);

            try
            {
                webSourceDownloader.DownloadSource(parametrs.Uri, 1);
            }
            catch (Exception exception)
            {
                logger.LogMessage(LogMessageType.Error, $"{DateTime.UtcNow} | {exception.Message} | {exception.StackTrace} | Uri - {parametrs.Uri} | Directory - {parametrs.Directory}");
            }

            Console.ReadKey();
        }

    }
}
