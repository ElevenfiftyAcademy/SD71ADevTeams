using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public int DevTeamId { get; set; }
        public string TeamName { get; set; }
        public List<Developer> ListOfDevelopers { get; set; } = new List<Developer>();

        public DevTeam() { }
        //public DevTeam (string name)
        //{
        //    TeamName = name;
        //}
        public DevTeam(string name, List<Developer> listOfDevelopers)
        {
            TeamName = name;
            ListOfDevelopers = listOfDevelopers;
        }

        //Add Developer(s) To Team
        public void AddDeveloperToTeam(List<Developer> developersToAdd)
        {
            ListOfDevelopers.AddRange(developersToAdd);
        }

        //Remove Developer From Team
        public void RemoveDeveloperFromTeam(Developer developer)
        {
            ListOfDevelopers.Remove(developer);
        }
    }
}
