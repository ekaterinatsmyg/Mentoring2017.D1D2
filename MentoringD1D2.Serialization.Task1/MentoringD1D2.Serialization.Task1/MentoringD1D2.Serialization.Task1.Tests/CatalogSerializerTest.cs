using System;
using System.Collections.Generic;
using System.IO;
using MentoringD1D2.Serialization.Task1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MentoringD1D2.Serialization.Task1.Tests
{
    [TestClass]
    public class CatalogSerializerTest
    {
        [TestMethod]
        public void SerializeTest()
        {
            Catalog catalog = new Catalog
            {
                Books = new List<Book>
                {
                    new Book()
                    {
                        Author = new Author() {Name = "Test Author Name 1"},
                        CreatedDate = DateTime.Now,
                        Genre = Genres.Computer,
                        Description =
                            "COM &amp; .NET Component Services provides both traditional COM programmers and new .NET component developers",
                        Id = 1,
                        PublishDate = DateTime.Now,
                        Title = "COM and .NET Component Services",
                        Publisher = "O'Reilly"
                    },
                    new Book()
                    {
                        Author = new Author() {Name = "Corets, Eva"},
                        CreatedDate = DateTime.Now,
                        Genre = Genres.Fantasy,
                        Description =
                            "After the collapse of a nanotechnology society in England, the young survivors lay the foundation for a new society",
                        Id = 2,
                        PublishDate = DateTime.Now,
                        Title = "Maeve Ascendant",
                        Publisher = "R &amp; D"
                    },
                    new Book()
                    {
                        Author = new Author() {Name = "Corets, Eva"},
                        CreatedDate = DateTime.Now,
                        Genre = Genres.Fantasy,
                        Description = "Sequel to Maeve",
                        Id = 3,
                        PublishDate = DateTime.Now,
                        Title = "Oberon's Legacy",
                        Publisher = "R &amp; D"
                    }
                }
            };

            var serializer = new CatalogSerializer();
            serializer.Serialize(catalog, @"E:\result_1.xml");
            var result = serializer.Deserialize(@"E:\result_1.xml");

            CollectionAssert.AreEqual(result.Books, catalog.Books);

        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void CatalogNullSerializeTest()
        {
            var serializer = new CatalogSerializer();
            serializer.Serialize(null, @"E:\result_1.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void CatalogIncorrectFilenameTest()
        {
            var serializer = new CatalogSerializer();
            serializer.Serialize(new Catalog(), @"K:\result_1.xml");
        }


        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DeserializeTest()
        {
            var serializer = new CatalogSerializer();
            serializer.Deserialize(@"E:\book_2.xml");
        }
    }
}
