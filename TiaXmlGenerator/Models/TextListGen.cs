using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaXmlGenerator.Models
{
    public class TextListGen
    {
        public string Name { get; set; }
        public List<string> Comment { get; set; }
        public List<TextlistEntry> Entries { get; set; }
        public int CulturesNumber { get; set; }

        public TextListGen(string name, int culturesNumber) 
        { 
            Name = name;
            Comment = new List<string>(culturesNumber);
            Entries = new List<TextlistEntry>();
            CulturesNumber = culturesNumber;
        }
    }
}
