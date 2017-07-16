using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task.Serializers
{
    public class GenericXmlSerializer<T> where T: class 
    {
        /// <summary>
        /// Serialize <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="entity">The instance of the <typeparamref name="T"/>.</param>
        /// <param name="filename">The name of the file in which will be written serialized instance.</param>
        /// <exception cref="ArgumentNullException">Appears when <param name="entity"></param> is null.</exception>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Appears when the selected file <param name="filename"></param> are in non-existent folder.</exception>
        public void Serialize(string filename, T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));

            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                throw new DirectoryNotFoundException($"Directory {Path.GetDirectoryName(filename)} does not exist.");

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var writer = new StreamWriter(filename))
            {
                xmlSerializer.Serialize(writer, entity);
            }
        }

        /// <summary>
        /// Deserialize xml file to <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="filename">The xml file with serialized entity of <typeparamref name="T"/> type.</param>
        /// <returns>The deserialized entity or null if the deserialization was unsuccessful.</returns>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Appears when <param name="filename"></param> was not found.</exception>
        public T Deserialize(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));

            if (!File.Exists(filename))
                throw new FileNotFoundException(nameof(filename));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T entity;

            using (var reader = XmlReader.Create(filename))
            {
                entity = xmlSerializer.Deserialize(reader) as T;
            }
            
            return entity;
        }
    }
}
