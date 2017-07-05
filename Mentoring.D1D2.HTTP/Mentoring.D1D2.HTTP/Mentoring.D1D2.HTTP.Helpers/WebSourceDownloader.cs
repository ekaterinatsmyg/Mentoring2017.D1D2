using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using MentoringD1D2.HTTP.Diagnostics;

namespace Mentoring.D1D2.HTTP.Helpers
{
    /// <summary>
    /// The type that provides functionality that helps to download web source.
    /// </summary>
    public class WebSourceDownloader
    {
        /// <summary>
        /// The instance of http cient.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// The max level of nesting.
        /// </summary>
        private readonly int _depth;

        /// <summary>
        /// The selected directory path.
        /// </summary>
        private readonly string _directoryPath;

        /// <summary>
        /// The extensions of downloading files.
        /// </summary>
        private readonly string[] _fileExtensions;

        /// <summary>
        /// The domain of root uri.
        /// </summary>
        private readonly bool _isWithinDomain;

        /// <summary>
        /// The extension of html file.
        /// </summary>
        private const string HtmlFileType = ".html";

        /// <summary>
        /// The instance of the type that need to log message to aplication log or console or file based on arguments.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initialize web source downloader instance.
        /// </summary>
        public WebSourceDownloader(string directoryPath, string[] fileExtensions, int depth, bool isWithinDomain, ILogger logger)
        {
            _httpClient = new HttpClient();
            _depth = depth;
            _directoryPath = directoryPath;
            _fileExtensions = fileExtensions;
            _isWithinDomain = isWithinDomain;
            _logger = logger;
        }

        /// <summary>
        /// Downloads source based the uri recursevly.
        /// </summary>
        /// <param name="uri">The uri of source.</param>
        /// <param name="currentDepth">The current level of nesting.</param>
        public void DownloadSource(string uri, int currentDepth)
        {
            if (currentDepth == _depth)
                return;

            _logger.LogMessage(LogMessageType.Info, $"Current source - {uri}");

            var filePath = SaveSourceToFile(uri);

            _logger.LogMessage(LogMessageType.Info, $"Downloaded file - {filePath}");

            if (Path.GetExtension(filePath) != HtmlFileType || String.IsNullOrEmpty(filePath))
                return;

            var childrenUri = FindChildren(filePath);

            var parentUri = new Uri(uri);
            var parentUriRoot = !String.IsNullOrEmpty(parentUri.Query) ? parentUri.AbsoluteUri.Replace(parentUri.Query, String.Empty) : parentUri.AbsoluteUri;

            foreach (var child in childrenUri)
            {
                if (!child.IsAbsoluteUri())
                {
                    DownloadSource($"{parentUriRoot}{child}", currentDepth + 1);
                }
                if ((_isWithinDomain && child.Contains(parentUriRoot)) || (child.IsAbsoluteUri() && !_isWithinDomain))
                {
                    DownloadSource(child, currentDepth + 1);
                }
            }
        }

        /// <summary>
        /// Search links to other sources that exist in saved web source.
        /// </summary>
        /// <param name="filePath">The path of the saved file.</param>
        /// <returns>The list of the links to other sources that exist in saved web source.</returns>
        private static List<string> FindChildren(string filePath)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);
            var nodes = htmlDocument.DocumentNode.SelectNodes("//@href | //@src");
            var childrenUri = new List<string>();

            if (nodes != null)
                childrenUri.AddRange(
                    nodes.Select(
                        node =>
                            node.GetAttributeValue("src", null) ??
                            node.GetAttributeValue("href", null) ?? String.Empty));
            return childrenUri;
        }

        /// <summary>
        /// Save link to file.
        /// </summary>
        /// <param name="uri">The uri of the source.</param>
        private string SaveSourceToFile(string uri)
        {
            using (var response = _httpClient.GetAsync(uri))
            {
                response.Result.EnsureSuccessStatusCode();
                _logger.LogMessage(LogMessageType.Info, $"The result of the responese - {response.Result} | Status: {response.Status}");
                return response.Result.Content.ReadAsFileAsync(uri, _directoryPath, _fileExtensions).Result;
            }
        }

    }
}

