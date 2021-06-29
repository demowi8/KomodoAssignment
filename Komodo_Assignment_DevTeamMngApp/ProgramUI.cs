using DeveloperClass;
using DevTeamClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Assignment_DevTeamMngApp
{
    public class ProgramUI
    {
        protected readonly Developer_Repository _developerInfo = new Developer_Repository();
        protected readonly DevTeamRepo_Repository _devTeamRepo = new DevTeamRepo_Repository(); 
        public void Run()
        {
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display option menu
                Console.WriteLine("Select a Menu option:\n" +
                    "1. View List of Developers\n" +
                    "2. Add a Developer\n" +
                    "3. Remove a Developer\n" +
                    "4. Add Teams\n" +
                    "5. View List of Teams\n" +
                    "6. Remove a Team\n" +
                    "7. Add Developer to a team\n" +
                    "8. Remove Developer from a team");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        ViewAllDevelopers();

                        break;
                    case "2":
                        AddDevelopers();

                        break;
                    case "3":
                        RemoveADeveloper();

                        break;
                    case "4":
                        AddADevTeam();

                        break;
                    case "5":
                        ViewListOfTeams();

                        break;
                    case "6":
                        RemoveATeam();

                        break;
                    case "7":
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        RemoveDeveloperFromTeam();
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //View all developers
        private void ViewAllDevelopers()
        {
            Console.Clear();

            //Get developers
            List<Developer> listOfMembers = _developerInfo.SeeDeveloperList();

            foreach (Developer members in listOfMembers)
            {
                Console.WriteLine(members);
            }

        }

        //Add developers
        private void AddDevelopers()
        {
            Console.Clear();

            Developer newDeveloper = new Developer();
            //first name
            Console.WriteLine("Enter the first name of the developer:");
            newDeveloper.FirstName = Console.ReadLine();

            //last name
            Console.WriteLine("Enter the last name of the developer:");
            newDeveloper.LastName = Console.ReadLine();

            //Name
            Console.WriteLine("Enter the first and last name of or nickname of developer:");
            newDeveloper.Name = Console.ReadLine();

            //NumberID
            Console.WriteLine("Enter the unique ID of the developer:");
            newDeveloper.NumberID = Console.ReadLine();

            //Access to plural sight
            Console.WriteLine("Does the developer have access to Plural Sight?");
            string YesOrNo = Console.ReadLine();
            if(YesOrNo == "Yes")
            {
                newDeveloper.AccessToPS = true;
            }
            else { newDeveloper.AccessToPS = false; }
        }

        //Remove developers
        private void RemoveADeveloper()
        {
            Console.Clear();
            //Select the members to delete
            //Get Content by title
            Console.WriteLine("Which member would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //DisplayAllContent
            List<Developer> listOfMembers = _developerInfo.SeeDeveloperList();
            foreach (Developer members in listOfMembers)
            {
                count++;
                Console.WriteLine($"{count}. {members.Name}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < listOfMembers.Count())
            {
                //Delete the members
                //Selecting object to be deleted
                Developer targetDeveloper = listOfMembers[targetIndex];
                //Check to see if deleted
                if (_developerInfo.RemoveContentFromList(targetDeveloper))
                {
                    //success message
                    Console.WriteLine($"{targetDeveloper.Name} removed from repo");
                }
                else
                {
                    //Fail Message
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            //If invalid input
            else
            {
                Console.WriteLine("Invalid Selection");
            }
        }

            //Add teams
            private void AddADevTeam()
        {
            Console.Clear();

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the name of the Development Team");
            newDevTeam.TeamName = Console.ReadLine();

        }

            //View list of teams
            private void ViewListOfTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeamRepo.SeeListOfTeams();
            
            foreach(DevTeam teams in listOfDevTeams)
            {
                Console.WriteLine(teams);
            }

        }

        //Remove a team
        private void RemoveATeam()
        {
            Console.Clear();
            //Select the team to delete
            //Get Content by title
            Console.WriteLine("Which team would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //DisplayAllContent
            List<DevTeam> listOfDevTeams = _devTeamRepo.SeeListOfTeams();
            foreach (DevTeam teams in listOfDevTeams)
            {
                count++;
                Console.WriteLine($"{count}. {teams.TeamName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < listOfDevTeams.Count())
            {
                //Delete the members
                //Selecting object to be deleted
                DevTeam targetDevTeam = listOfDevTeams[targetIndex];
                //Check to see if deleted
                if (_devTeamRepo.RemoveTeamFromList(targetDevTeam))
                {
                    //success message
                    Console.WriteLine($"{targetDevTeam.TeamName} removed from repo");
                }
                else
                {
                    //Fail Message
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            //If invalid input
            else
            {
                Console.WriteLine("Invalid Selection");
            }
        }


        //Add a developer to a team
        private void AddDeveloperToTeam()
        {
            Console.Clear();
            //What Team are you adding to?
            List<DevTeam> listOfDevTeams = _devTeamRepo.SeeListOfTeams();

            foreach (DevTeam teams in listOfDevTeams)
            {
                Console.WriteLine(teams);
            }
            Console.WriteLine("What Team do you want to add to?");
            string TeamName = Console.ReadLine();

            //Get list of developers
            List<Developer> listOfMembers = _developerInfo.SeeDeveloperList();

            foreach (Developer members in listOfMembers)
            {
                Console.WriteLine(members);
            }
            Console.WriteLine("Which developer do you want to add?");
            string Name = Console.ReadLine();

            //Select from list of developers
            Developer developer = _developerInfo.GetDeveloperByName(Name);
            DevTeam devTeam = _devTeamRepo.GetTeamByName(TeamName);
            devTeam.ListOfMembers.Add(developer);


        }

        //Remove a developer from a team
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            //What Team do you want to remove from?
            List<DevTeam> listOfDevTeams = _devTeamRepo.SeeListOfTeams();

            foreach (DevTeam teams in listOfDevTeams)
            {
                Console.WriteLine(teams);
            }
            Console.WriteLine("What Team do you want to remove from?");
            string TeamName = Console.ReadLine();
            //Which developer do you want to remove?
            List<Developer> devTeamMembers = _developerInfo.SeeDeveloperList();
            DevTeam devTeam = _devTeamRepo.GetTeamByName(TeamName);
            foreach (Developer members in devTeam.ListOfMembers)
            {
                Console.WriteLine(members);
            }
            Console.WriteLine("Which developer do you want to remove?");
            string Name = Console.ReadLine();

            //Select and Remove
            Developer RemoveFromTeam = _developerInfo.GetDeveloperByName(Name);
            devTeam.ListOfMembers.Remove(RemoveFromTeam);
        }


    }
}
