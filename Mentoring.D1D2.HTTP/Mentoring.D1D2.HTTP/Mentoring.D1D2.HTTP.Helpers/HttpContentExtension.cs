using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Mentoring.D1D2.HTTP.Helpers
{
    /// <summary>
    /// The extension of <c>HttpContent</c> functionality.
    /// </summary>
    public static class HttpContentExtension
    {
        /// <summary>
        /// The content type that means - requested source is html document.
        /// </summary>
        private const string HtmlFileType = "text/html";

        /// <summary>
        /// The content type that means - requested source is html document.
        /// </summary>
        private const string HtmlFileTypeExtenxion = ".html";

        /// <summary>
        /// The max number of symbols that is avaliable for file name.
        /// </summary>
        private const int MaxPathLenght = 248;

        /// <summary>
        /// Create file based on httpcontent, content type and save to selected <c>directoryPath</c>.
        /// </summary>
        /// <param name="content">The content that was requested by uri.</param>
        /// <param name="uri">The uri of requested source.</param>
        /// <param name="directoryPath">The output directory for generated file.</param>
        /// <param name="fileExtensions">The types of files that should be downloaded.</param>
        /// <returns></returns>
        public static async Task<string> ReadAsFileAsync(this HttpContent content, string uri, string directoryPath, string fileExtensions)
        {
            var filePath = CreateValidFilePath(content, directoryPath,uri);
            var extensions = fileExtensions.Split(',');
            if (!String.IsNullOrEmpty(fileExtensions))
            {
                var fileExtension = Path.GetExtension(filePath);
                if (!extensions.Any(x => x.Contains(fileExtension)) && fileExtension != HtmlFileTypeExtenxion)
                    return String.Empty;
            }
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                await content.CopyToAsync(fileStream).ContinueWith(
                    (copyTask) =>
                    {
                        fileStream.Close();
                    });
                return filePath;
            }
            catch
            {
                fileStream?.Close();

                throw;
            }
            return String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="directoryPath"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static string CreateValidFilePath(HttpContent content, string directoryPath, string uri)
        {
            string fileName;
            if (content.Headers.ContentType.MediaType == HtmlFileType)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(uri);
                fileName = $"{document.DocumentNode.SelectSingleNode("//head/title").InnerText}.html";
            }
            else
            {
                fileName = uri.Split('/').Last();
            }
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
            }
            string filePath = $"{directoryPath}\\{fileName}";
            if (filePath.Length >= MaxPathLenght)
            {
                var extension = Path.GetExtension(fileName);
                var createdDate = DateTime.Now;
                filePath = $"{directoryPath}\\{createdDate.Month}-{createdDate.Day}-{createdDate.Year}_{createdDate.Minute}_{createdDate.Second}{extension}";
            }
            return filePath;
        }
    }
}
