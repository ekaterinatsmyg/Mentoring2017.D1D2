using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Task.Serializers
{
    public class GenericDataContractSerializer<T> where T : class 
    {
        private readonly DataContractSerializer _dataContractSerializer;

        public GenericDataContractSerializer()
        {
            _dataContractSerializer = new DataContractSerializer(typeof(T));
    } 

        public GenericDataContractSerializer(IDataContractSurrogate surrogate)
        {
            _dataContractSerializer = new DataContractSerializer(typeof(T), new DataContractSerializerSettings() {DataContractSurrogate = surrogate});
        } 

        /// <summary>
        /// Serialize <typeparamref name="T"/> instance to binary format.
        /// </summary>
        /// <param name="entity">The instance of the <typeparamref name="T"/>.</param>
        /// <param name="fileName">The name of the file in which will be written serialized instance.</param>
        /// <exception cref="ArgumentNullException">Appears when <param name="entity"></param> is null.</exception>
        /// <exception cref="ArgumentException">Appears when <param name="fileName"></param> is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Appears when the selected file <param name="fileName"></param> are in non-existent folder.</exception>
        public void WriteObject(string fileName, T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException(nameof(fileName));

            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                throw new DirectoryNotFoundException($"Directory {Path.GetDirectoryName(fileName)} does not exist.");
            
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                _dataContractSerializer.WriteObject(writer, entity);
            }
        }

        /// <summary>
        /// Deserialize xml file to <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="fileName">The xml file with serialized entity of <typeparamref name="T"/> type.</param>
        /// <returns>The deserialized entity or null if the deserialization was unsuccessful.</returns>
        /// <exception cref="ArgumentException">Appears when <param name="fileName"></param> is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Appears when <param name="fileName"></param> was not found.</exception>
        public T ReadObject(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException(nameof(fileName));

            if (!File.Exists(fileName))
                throw new FileNotFoundException(nameof(fileName));
            
            T desirializedEntity;

            using (FileStream stream = new FileStream(fileName,FileMode.Open))
            {
                using (var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    desirializedEntity = _dataContractSerializer.ReadObject(reader, true) as T;
                }
               
            }
            return desirializedEntity;

        }
    }
}
