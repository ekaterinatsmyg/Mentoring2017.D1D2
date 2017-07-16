using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Task.Serializers
{
    public class GenericSoapFormatter<T> where T : class
    {
        /// <summary>
        /// Deserialize xml file to <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="filename">The xml file with serialized entity of <typeparamref name="T"/> type.</param>
        /// <param name="selector">The surrogate selector.</param>
        /// <returns>The deserialized entity or null if the deserialization was unsuccessful.</returns>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Appears when <param name="filename"></param> was not found.</exception>
        public T Deserialize(string filename, ISurrogateSelector selector)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));

            if (!File.Exists(filename))
                throw new FileNotFoundException(nameof(filename));

            var soapFormatter = new SoapFormatter(selector, new StreamingContext());
            T entity;

            using (var reader = new FileStream(filename, FileMode.Open))
            {
                entity = soapFormatter.Deserialize(reader) as T;
            }

            return entity;
        }

        /// <summary>
        /// Serialize <typeparamref name="T"/> instance to binary format.
        /// </summary>
        /// <param name="entity">The instance of the <typeparamref name="T"/>.</param>
        /// <param name="filename">The name of the file in which will be written serialized instance.</param>
        /// <param name="selector">The surrogate selector.</param>
        /// <exception cref="ArgumentNullException">Appears when <param name="entity"></param> is null.</exception>
        /// <exception cref="ArgumentException">Appears when <param name="filename"></param> is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Appears when the selected file <param name="filename"></param> are in non-existent folder.</exception>
        public void Serialize(string filename, T entity, ISurrogateSelector selector)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(nameof(filename));

            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                throw new DirectoryNotFoundException($"Directory {Path.GetDirectoryName(filename)} does not exist.");

            var soapFormatter = new SoapFormatter(selector, new StreamingContext());

            using (var writer = new FileStream(filename, FileMode.Create))
            {
                soapFormatter.Serialize(writer, entity);
            }
        }
    }
}
