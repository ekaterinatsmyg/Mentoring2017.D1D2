using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MentoringD1D2.Serialization.Task1.Models
{
    [Serializable]
    public class Author
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
