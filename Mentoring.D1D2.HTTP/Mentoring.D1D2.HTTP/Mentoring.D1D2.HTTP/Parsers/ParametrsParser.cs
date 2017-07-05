using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.HTTP.Diagnostics;
using Microsoft.Practices.Unity;

namespace Mentoring.D1D2.HTTP.Parsers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ParametrsParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="parametrsModel"></param>
        /// <param name="unityContainer"></param>
        /// <returns></returns>
        public static bool TryParse(string[] args, out ParametrsModel parametrsModel, UnityContainer unityContainer)
        {
            Dictionary<string, string> parametrs;

            if (TryParseArguments(args, out parametrs))
                return IsParametrsValid(parametrs, out parametrsModel, unityContainer);

            parametrsModel = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametrs"></param>
        /// <param name="parametrsModel"></param>
        /// <returns></returns>
        private static bool IsParametrsValid(Dictionary<string, string> parametrs, out ParametrsModel parametrsModel, UnityContainer unityContainer)
        {
            parametrsModel = new ParametrsModel();
            foreach (var parametr in parametrs)
            {
                switch (parametr.Key)
                {
                    case "uri":
                        parametrsModel.Uri = parametr.Value;
                        break;

                    case "dir":
                        parametrsModel.Directory = parametr.Value;
                        break;

                    case "ext":
                        parametrsModel.Extensions = parametr.Value.Split(',');
                        break;

                    case "l":
                        int level;
                        if (!int.TryParse(parametr.Value, out level))
                        {
                            Console.WriteLine(
                                $"The level parametr {parametr} is not a number. The default value = 0 was selected");
                            parametrsModel.Level = 0;
                        }
                        parametrsModel.Level = level;
                        break;

                    case "d":
                        bool isDomain;
                        if (!bool.TryParse(parametr.Value, out isDomain))
                        {
                            Console.WriteLine(
                                $"The level parametr {parametr} is not a number. The default value = 0 was selected");
                            parametrsModel.IsDomain = false;
                        }
                        parametrsModel.IsDomain = isDomain;
                        break;

                    case "log":
                        var container = new UnityContainer();
                        switch (parametr.Value)
                        {
                            case "event":
                                parametrsModel.IsEventLogger = true;
                                break;
                            case "app":
                                parametrsModel.IsEventLogger = false;
                                break;
                            default:
                                Console.WriteLine(
                                    $"The log parametr {parametr} doesn't exist. The appropriate values: event/app");
                                return false;
                        }
                        break;

                    default:
                        Console.WriteLine($"The {parametr.Key} command doesn't exist. The command pattern is: -(name of the parametr):value");
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out Dictionary<string, string> parametrs)
        {
            parametrs = new Dictionary<string, string>();

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    var argument = args[i].Substring(1);
                    var nameValue = argument.Split(':');
                    parametrs.Add(nameValue[0], nameValue.Length == 1 ? null : nameValue[1]);
                }
                else
                {
                    Console.WriteLine($"Incorrect command. The comand {args[i]} doesn't exist.");
                    return false;
                }
            }
            return true;
        }
    }
}
