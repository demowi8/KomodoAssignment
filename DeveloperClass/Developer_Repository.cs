using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperClass
{
    //Create a POCO
    public class Developer_Repository
    {
        //Field
        protected readonly List<Developer> _developerInfo = new List<Developer>();
        //CRUD 
        //CREATE
        public bool AddDeveloper(Developer developerInfo)
        {
            int countDevelopers = _developerInfo.Count;
            _developerInfo.Add(developerInfo);
            bool isDeveloper = (_developerInfo.Count > countDevelopers) ? true : false;
            return isDeveloper;     
        }

        //READ
        public List<Developer>  SeeDeveloperList()
        {
            return _developerInfo;
        }
        public Developer GetDeveloperByName(string Name)
        {
            //get directory
            //sort through all developers using name 
            foreach(Developer developerInfo in _developerInfo)
            {
                if(developerInfo.Name.ToLower() == Name.ToLower())
                {
                    return developerInfo;
                }
            }
            return null;
        }

        //UPDATE

        public bool UpdateDeveloperInfo(string Name, Developer newDeveloper)
        {
            //Find Developer
            Developer oldDeveloper = GetDeveloperByName(Name);
            //Update developerInfo
            if(oldDeveloper != null)
            {
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.NumberID = newDeveloper.NumberID;
                return true;
            }
            else
            {
                return false;
            }

        }


        //DELETE
        public bool RemoveContentFromList(Developer developers)
        {
            bool removeDeveloper = _developerInfo.Remove(developers);
            return removeDeveloper;
        }
    }
}
