using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamClass
{
    public class DevTeamRepo_Repository
    {
        //field
        protected readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //CRUD
        //CREATE
        public bool AddDeveloperTeam(DevTeam devTeam)
        {
            int countDeveloperTeams = _devTeams.Count;
            _devTeams.Add(devTeam);
            bool devTeamAdded = (_devTeams.Count > countDeveloperTeams) ? true : false;
            return devTeamAdded;
        }
        //READ
        public List<DevTeam> SeeListOfTeams()
        {
            return _devTeams;
        }
        public DevTeam GetTeamByName(string TeamName)
        {
            //get directory
            //sorting through teams by name
            foreach(DevTeam devTeam in _devTeams)
            {
                if(devTeam.TeamName.ToLower() == TeamName.ToLower())
                {
                    return devTeam; 
                }
            }
            return null;
        }
        //UPDATE

        public bool UpdateTeamInfo(string TeamName, DevTeam newDevTeam)
        {
            //Find Dev Team
            DevTeam oldDevTeam = GetTeamByName(TeamName);
            //Update team info
            if(oldDevTeam != null)
            {
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.ListOfMembers = newDevTeam.ListOfMembers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool RemoveTeamFromList(DevTeam devTeam)
        {
            bool removeDevTeam = _devTeams.Remove(devTeam);
            return removeDevTeam;
        }
    }
}
