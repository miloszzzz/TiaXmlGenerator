using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaXmlGenerator.Models
{
    public class AddinScreen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public AddinScreen(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public AddinScreen(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }


    
}
