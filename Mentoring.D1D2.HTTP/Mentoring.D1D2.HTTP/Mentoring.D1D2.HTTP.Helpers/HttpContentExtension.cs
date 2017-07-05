using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.String;

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
        /// Create file based on httpcontent, content type and save to selected <c>directoryPath</c>.
        /// </summary>
        /// <param name="content">The content that was requested by uri.</param>
        /// <param name="uri">The uri of requested source.</param>
        /// <param name="directoryPath">The output directory for generated file.</param>
        /// <param name="fileExtensions">The types of files that should be downloaded.</param>
        /// <returns>The file path of the saved web source.</returns>
        public static async Task<string> ReadAsFileAsync(this HttpContent content, string uri, string directoryPath, string[] fileExtensions)
        {
            var filePath = CreateValidFilePath(content, directoryPath, uri);

            var fileExtension = Path.GetExtension(filePath);
            if (fileExtensions != null  && fileExtensions.All(x => x != fileExtension))
                return Empty;

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
        }

        /// <summary>
        /// Generate filename that will be saved.
        /// </summary>
        /// <param name="content">The content that was requested by uri.</param>
        /// <param name="directoryPath">The directory path of the selected folder where will be saved web source.</param>
        /// <param name="uri">The uri of requested source.</param>
        /// <returns>The generated filename of the saving web soure.</returns>
        private static string CreateValidFilePath(HttpContent content, string directoryPath, string uri)
        {
            string fileName;

            if (content.Headers.ContentType.MediaType == HtmlFileType)
            {
                var createdDate = DateTime.Now;
                fileName = $"{createdDate.Month}-{createdDate.Day}-{createdDate.Year}_{createdDate.Minute}_{createdDate.Second}.html";
            }
            else
            {
                fileName = uri.Split('/').Last();
            }

            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), Empty));
            }

            string filePath = $"{directoryPath}\\{fileName}";
            
            return filePath;
        }
    }
}
