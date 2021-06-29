using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperClass
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string NumberID { get; set; }
        public bool AccessToPS { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, string name, string numberID, bool accessToPS)
        {
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            NumberID = numberID;
            AccessToPS = accessToPS;
        }
    }
}
