using DeveloperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamClass
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public List<Developer> ListOfMembers { get; set; } = new List<Developer>();
        public DevTeam() { }
        public DevTeam(string teamName, List<Developer> developers)
        {
            TeamName = teamName;
            ListOfMembers = developers;
        }
    }
}
