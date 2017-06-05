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
    public class HttpHelper
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
        private readonly string _fileExtensions;

        /// <summary>
        /// The domain of root uri.
        /// </summary>
        private readonly bool _isWithinDomain;

        /// <summary>
        /// The extension of html file.
        /// </summary>
        private const string HtmlFileType = ".html";

        /// <summary>
        /// 
        /// </summary>
        public HttpHelper(string directoryPath, string fileExtensions = null, int depth = 1, bool isWithinDomain = false)
        {
            _httpClient = new HttpClient();
            _depth = depth;
            _directoryPath = directoryPath;
            _fileExtensions = fileExtensions;
            _isWithinDomain = isWithinDomain;
        }

        /// <summary>
        /// Downloads source based the uri.
        /// </summary>
        /// <param name="uri">The uri of source.</param>
        public void DownloadSource(string uri)
        {
            DownloadSource(uri, 1, _directoryPath, _fileExtensions);
        }

        /// <summary>
        /// Downloads source based the uri recursevly.
        /// </summary>
        /// <param name="uri">The uri of source.</param>
        /// <param name="currentDepth">The current level of nesting.</param>
        /// <param name="directoryPath">The selected directory path.</param>
        /// <param name="fileExtensions">The extensions of downloading files.</param>
        private void DownloadSource(string uri, int currentDepth, string directoryPath, string fileExtensions)
        {
            if (currentDepth == _depth)
                return;
            ApplicationLogger.LogMessage(LogMessageType.Info, $"Current source - {uri}");
            var filePath = DownloadSource(uri, directoryPath, fileExtensions);
            ApplicationLogger.LogMessage(LogMessageType.Info, $"Downloaded file - {filePath}");
            if (Path.GetExtension(filePath) != HtmlFileType || String.IsNullOrEmpty(filePath)) return;
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
            var parentUri = new Uri(uri);
            var parentUriRoot = !String.IsNullOrEmpty(parentUri.Query) ? parentUri.AbsoluteUri.Replace(parentUri.Query, String.Empty) : parentUri.AbsoluteUri;
            foreach (var child in childrenUri)
            {
                if (!child.IsAbsoluteUri())
                {
                    DownloadSource($"{parentUriRoot}{child}", currentDepth + 1,
                        directoryPath,
                        fileExtensions);
                }
                if (_isWithinDomain && child.Contains(parentUriRoot))
                {
                    DownloadSource(child, currentDepth + 1, directoryPath, fileExtensions);
                }
            }
        }

        /// <summary>
        /// Save link to file.
        /// </summary>
        /// <param name="uri">The uri of source.</param>
        /// <param name="directoryPath">The path of a saved file.</param>
        /// <param name="fileExtensions">The extensions of downloading files.</param>
        private string DownloadSource(string uri, string directoryPath, string fileExtensions)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentException(nameof(uri));

            if (string.IsNullOrEmpty(directoryPath))
                throw new ArgumentException(nameof(directoryPath));

            using (var response = _httpClient.GetAsync(uri))
            {
                response.Result.EnsureSuccessStatusCode();
                return response.Result.Content.ReadAsFileAsync(uri, directoryPath, fileExtensions).Result;

            }
        }

    }
}

