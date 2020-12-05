using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public int DeveloperID { get; set; }
        public string Name { get; set; }
        public bool HasPluralsight { get; set; }

        public Developer(string name, bool hasPluralsight)
        {
            Name = name;
            HasPluralsight = hasPluralsight;
        }
    }
}
