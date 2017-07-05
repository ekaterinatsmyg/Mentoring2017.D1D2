using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MentoringD1D2.Serialization.Task1.Models
{
    [Serializable]
    public class Book
    {
        #region Properties

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("author")]
        public Author Author { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(DataType = "date", ElementName = "publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement(ElementName = "publisher")]
        public string Publisher { get; set; }

        [XmlElement(ElementName = "genre")]
        public Genres Genre { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(DataType = "date", ElementName = "registration_date")]
        public DateTime CreatedDate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The references  equality of objects
        /// </summary>
        /// <param name="obj">The compared developer instance</param>
        /// <returns>If instances of the developers are equality, it will return true, else false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            Book book = obj as Book;
            if (book == null)
                return false;

            return book.Id == Id && book.Publisher == Publisher && book.Title == Title && book.Genre == Genre;

        }

        #endregion

    }
}
