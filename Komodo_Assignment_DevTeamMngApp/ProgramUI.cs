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
                        RemoveDeveloper();

                        break;
                    case "4":
                        AddTeams();

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
            newDeveloper.AccessToPS = Console.ReadLine(true || false);
        }

        //Remove developers
        private void RemoveADeveloper()
        {
            Console.Clear();
            //Select the members to delete
            //Get Content by title
            Console.WriteLine("What title would you like to remove?");

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
                Developer targetContent = listOfMembers[targetIndex];
                //Check to see if deleted
                if (_developerInfo.RemoveContentFromList(targetContent))
                {
                    //success message
                    Console.WriteLine($"{targetContent.Name} removed from repo");
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

            DevTeam newDevTeam 
        }

            //View list of teams
            //Remove a team
            //Add a developer to a team
            //Remove a developer from a team
    }
}
