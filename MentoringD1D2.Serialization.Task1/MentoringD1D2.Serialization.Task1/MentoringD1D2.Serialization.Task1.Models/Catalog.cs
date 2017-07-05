using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MentoringD1D2.Serialization.Task1.Models
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlArrayItem("book"), XmlArray("books")]
        public List<Book> Books { get; set; } 
    }
}
