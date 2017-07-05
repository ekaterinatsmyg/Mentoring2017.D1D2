using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MentoringD1D2.Serialization.Task1.Models
{
    [Serializable]
    public enum Genres
    {
        [XmlEnum]
        Computer,

        [XmlEnum]
        Fantasy,

        [XmlEnum]
        Romance,

        [XmlEnum]
        Horror,

        [XmlEnum("Since Fiction")]
        SinceFiction

    }
}
