using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.HTTP.Diagnostics;

namespace Mentoring.D1D2.HTTP.Parsers
{
    public class ParametrsModel
    {

        public string Uri { get; set; }

        public string Directory { get; set; }

        public int Level { get; set; }

        public bool IsDomain { get; set; }

        public string[] Extensions { get; set; }

        public bool IsEventLogger { get; set; }
    }
}
