using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();
        private int _devIdCounter = 0;

        //Developer Create
        public void AddDeveloperToDirectory(Developer developer)
        {
            developer.DeveloperID = _devIdCounter + 1;
            _developerDirectory.Add(developer);
            _devIdCounter++;
        }

        //DevelopersRead
        public List<Developer> GetAllDevelopers()
        {
            return _developerDirectory;
        }

        //Developer Read
        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int id)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.DeveloperID == id)
                {
                    return developer;
                }
            }
            return null;
        }

        //Developer Update
        public bool UpdateDeveloper(int developerId, Developer newDeveloperProps)
        {
            Developer existingDeveloper = GetDeveloperById(developerId);

            if (existingDeveloper != null)
            {
                existingDeveloper.Name = newDeveloperProps.Name;
                existingDeveloper.HasPluralsight = newDeveloperProps.HasPluralsight;

                return true;
            }
            return false;
        }

        //Developer Delete
        public bool RemoveDeveloper(int developerId)
        {
            Developer developer = GetDeveloperById(developerId);
            if (_developerDirectory.Remove(developer))
            {
                return true;
            }
            return false;
        }

    }
}
