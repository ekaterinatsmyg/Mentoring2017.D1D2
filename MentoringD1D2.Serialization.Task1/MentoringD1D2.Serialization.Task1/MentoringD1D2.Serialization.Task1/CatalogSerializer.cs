using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MentoringD1D2.Serialization.Task1.Models;

namespace MentoringD1D2.Serialization.Task1
{
    /// <summary>
    /// The type that helps to represent <c>Catalog</c> entities as xml.
    /// </summary>
    public class CatalogSerializer
    {
        /// <summary>
        /// Serialize <typeparamref name="Catalog"/> instance.
        /// </summary>
        /// <param name="catalog">The instance of the <typeparamref name="Catalog"/>.</param>
        /// <param name="filename">The name of the file in which will be written serialized instance.</param>
        /// <exception cref="ArgumentNullException">Appears when <param name="catalog"></param> is null.</exception>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Appears when the selected file <param name="filename"></param> are in non-existent folder.</exception>
        public void Serialize(Catalog catalog, string filename)
        {
            if (catalog == null)
                throw new ArgumentNullException(nameof(catalog));
            
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));
            
            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                throw new DirectoryNotFoundException($"Directory {Path.GetDirectoryName(filename)} does not exist.");

            var xmlSerializer = new XmlSerializer(typeof(Catalog));

            using (var writer = new StreamWriter(filename))
            {
                xmlSerializer.Serialize(writer, catalog);
            }
        }

        /// <summary>
        /// Deserialize xml file to <typeparamref name="Catalog"/> instance.
        /// </summary>
        /// <param name="filename">The xml file with serialized entity of <typeparamref name="Catalog"/> type.</param>
        /// <returns>The deserialized entity or null if the deserialization was unsuccessful.</returns>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Appears when <param name="filename"></param> was not found.</exception>
        public Catalog Deserialize(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));

            if (!File.Exists(filename))
                throw new FileNotFoundException(nameof(filename));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Catalog));
            Catalog catalog;

            using (var reader = XmlReader.Create(filename))
            {
                catalog = xmlSerializer.Deserialize(reader) as Catalog;
            }

            return catalog;
        }
    }
}
