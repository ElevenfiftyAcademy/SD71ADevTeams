using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsConsole
{
    public class ProgramUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!\n" +
                "Press an key to exit...");
            Console.ReadKey();
        }

        private void SeedData()
        {
            var michael = new Developer("Michael Pabody", true);
            var casey = new Developer("Casey Wilson", false);
            var terry = new Developer("Terry Brown", true);
            var seth = new Developer("Seth Tennyson", false);
            var drew = new Developer("Drew Graber", true);
            var simon = new Developer("Simon Pawlak", true);
            var peyton = new Developer("Peyton Cooper", false);
            var jess = new Developer("Jess Schultz", true);
            var mitch = new Developer("Mitchell Reed", false);
            _devRepo.AddDeveloperToDirectory(michael);
            _devRepo.AddDeveloperToDirectory(casey);
            _devRepo.AddDeveloperToDirectory(terry);
            _devRepo.AddDeveloperToDirectory(seth);
            _devRepo.AddDeveloperToDirectory(drew);
            _devRepo.AddDeveloperToDirectory(simon);
            _devRepo.AddDeveloperToDirectory(peyton);
            _devRepo.AddDeveloperToDirectory(jess);
            _devRepo.AddDeveloperToDirectory(mitch);

            var team1 = new DevTeam("Best Team Ever", new List<Developer>() { seth, terry, peyton });
            _devTeamRepo.AddTeamToDirectory(team1);

            var team2 = new DevTeam("Not Bad", new List<Developer>() { casey, drew, jess });
            _devTeamRepo.AddTeamToDirectory(team2);

            var team3 = new DevTeam("ehh...", new List<Developer>() { mitch, simon, michael });
            _devTeamRepo.AddTeamToDirectory(team3);
        }

        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the DevTeam Menu. Please select an option.\n\n" +
                "1. View all Developers\n" +
                "2. Add a new Developer\n" +
                "3. Update a Developer\n" +
                "4. Delete a Developer\n" +
                "5. See which developers still need acces to Pluralsight\n\n" +
                "6. View all Teams\n" +
                "7. Add a new Team\n" +
                "8. Update a Team\n" +
                "9. Delete a Team\n\n" +
                "0. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    //Display all Developers
                    DisplayAllDevelopers();
                    break;
                case "2":
                    //Create a developer
                    CreateNewDeveloper();
                    break;
                case "3":
                    //Update an existing developer
                    UpdateExistingDeveloper();
                    break;
                case "4":
                    //Delete a developer
                    DeleteExistingDeveloper();
                    break;
                case "5":
                    //Pluralsight report
                    PluralsightReport();
                    break;
                case "6":
                    //View all teams
                    DisplayAllDevTeams();
                    break;
                case "7":
                    //Add a new team
                    CreateNewDevTeam();
                    break;
                case "8":
                    //Update a team
                    UpdateExistingDevTeam();
                    break;
                case "9":
                    //Delete a Team
                    DeleteDevTeam();
                    break;
                case "0":
                    //Exit
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            return true;
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();
            var allDevelopers = _devRepo.GetAllDevelopers();
            foreach (var developer in allDevelopers)
            {
                DisplayDeveloper(developer);
            }
            Console.WriteLine();
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the developer.");
            string developerName = Console.ReadLine();

            Console.WriteLine("Does the developer have access to Pluralsight? (y/n)");
            bool pluralsightAccess = GetYesNoAnswer();

            Developer newDeveloper = new Developer(developerName, pluralsightAccess);
            _devRepo.AddDeveloperToDirectory(newDeveloper);

        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Enter the ID of the developer you'd like to update");
            int devId = int.Parse(Console.ReadLine());
            DisplayDeveloper(_devRepo.GetDeveloperById(devId));
            Console.WriteLine("Enter the new name of the developer.");
            string developerName = Console.ReadLine();

            Console.WriteLine("Does the developer currently have access to Pluralsight? (y/n)");
            bool pluralsightAccess = GetYesNoAnswer();

            var updatedValues = new Developer(developerName, pluralsightAccess);
            _devRepo.UpdateDeveloper(devId, updatedValues);
        }

        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Enter the ID of the developer you'd like to delete.");
            int devId = int.Parse(Console.ReadLine());
            Console.Clear();
            var developerToDelete = _devRepo.GetDeveloperById(devId);
            DisplayDeveloper(developerToDelete);
            Console.WriteLine("Are you sure you want to delete this developer?");
            if (GetYesNoAnswer())
            {
                if (_devRepo.RemoveDeveloper(devId))
                {
                    Console.WriteLine("The developer was successfully deleted");
                }
                else
                {
                    Console.WriteLine("The developer could not be deleted");
                }
            }
        }

        private void PluralsightReport()
        {
            Console.Clear();
            Console.WriteLine("The following Developers do not currently have access to Pluralsight\n");
            foreach (var developer in _devRepo.GetAllDevelopers())
            {
                if (developer.HasPluralsight == false)
                {
                    DisplayDeveloper(developer);
                }
            }
        }

        private void DisplayAllDevTeams()
        {
            Console.Clear();
            var allDevTeams = _devTeamRepo.GetAllDevTeams();
            foreach (var devTeam in allDevTeams)
            {
                DisplayDevTeam(devTeam);
            }
        }

        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the name of the Team");
            newDevTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Would you like to add any developers to this team right now?");
            bool answer = GetYesNoAnswer();
            if (answer)
            {
                newDevTeam.ListOfDevelopers = GetDevsToAddToTeam();
            }
            else
            {
                Console.WriteLine("Ok you can always do that later by selecting Update a Team from the main menu.");
            }
            Console.WriteLine();
            _devTeamRepo.AddTeamToDirectory(newDevTeam);
        }

        private void UpdateExistingDevTeam()
        {
            Console.Clear();
            DisplayAllDevTeams();

            Console.WriteLine("Enter the ID of the DevTeam you'd like to update");
            int devTeamId = int.Parse(Console.ReadLine());

            DevTeam teamToUpdate = _devTeamRepo.GetTeamById(devTeamId);
            DisplayDevTeam(teamToUpdate);

            Console.WriteLine("Would you like to:\n\n" +
                "1. Add Developers to this team\n" +
                "2. Remove Developers from this team\n" +
                "3. Update the team name");

            switch (Console.ReadLine())
            {
                case "1":
                    List<Developer> devsToAdd = GetDevsToAddToTeam();
                    teamToUpdate.AddDeveloperToTeam(devsToAdd);
                    break;
                case "2":
                    Developer devToRemove = GetDeveloperToRemoveFromTeam();
                    teamToUpdate.RemoveDeveloperFromTeam(devToRemove);
                    break;
                case "3":
                    Console.WriteLine("Enter the new name for this team");
                    string newName = Console.ReadLine();
                    _devTeamRepo.UpdateDevleoper(devTeamId, newName);
                    break;
            }
        }

        private void DeleteDevTeam()
        {
            DisplayAllDevTeams();
            Console.WriteLine("Enter the ID of the DevTeam you'd like to delete.");
            int teamToDelete = int.Parse(Console.ReadLine());

            bool wasDeleted = _devTeamRepo.RemoveTeamFromDirectory(teamToDelete);
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted");
            }
            else
            {
                Console.WriteLine("The team could not be deleted");
            }
        }

        private List<Developer> GetDevsToAddToTeam()
        {
            DisplayAllDevelopers();

            Console.WriteLine("Please enter the IDs of the developers you would like to add to a team seperated by a comma.");
            List<string> listOfDevIDsAsString = Console.ReadLine().Split(',').ToList();

            var listOfDevsToAdd = new List<Developer>();
            //var listOfDevIDsAsInt = listOfDevIDsAsString.Select(int.Parse).ToList();

            foreach (string idAsString in listOfDevIDsAsString)
            {
                int idAsInt = int.Parse(idAsString);

                Developer developerToAdd = _devRepo.GetDeveloperById(idAsInt);
                listOfDevsToAdd.Add(developerToAdd);
            }
            return listOfDevsToAdd;
        }

        private Developer GetDeveloperToRemoveFromTeam()
        {
            Console.WriteLine("Enter the ID of the developer you'd like to remove");
            int devID = int.Parse(Console.ReadLine());
            Developer devToRemove = _devRepo.GetDeveloperById(devID);
            return devToRemove;
        }

        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }

        private void DisplayDeveloper(Developer developer)
        {
            Console.WriteLine($"\tID: {developer.DeveloperID}");
            Console.WriteLine($"\tName: {developer.Name}");
            if (developer.HasPluralsight == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tPluralsight: NO ACCESS");
                Console.ResetColor();
            }
            else if (developer.HasPluralsight == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\tPluralsight: Has Access");
                Console.ResetColor();
            }
            DisplayTeamName(developer);

        }

        private void DisplayDevTeam(DevTeam devTeam)
        {
            Console.WriteLine($"TeamID: {devTeam.DevTeamId}");
            Console.WriteLine($"Team Name: {devTeam.TeamName}\n");
            Console.WriteLine("Team Members");
            foreach (var developer in devTeam.ListOfDevelopers)
            {
                DisplayDeveloper(developer);
            }
        }

        private void DisplayTeamName(Developer developer)
        {
            foreach (var devTeam in _devTeamRepo.GetAllDevTeams())
            {
                if (devTeam.ListOfDevelopers.Contains(developer))
                {
                    Console.WriteLine($"\tTeam Name: {devTeam.TeamName}");
                }
            }
            Console.WriteLine();
        }
    }
}
