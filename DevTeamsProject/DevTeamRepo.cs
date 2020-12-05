using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeamsDirectory = new List<DevTeam>();
        private int _devTeamIdCounter = 0;

        //DevTeam Create (add)
        public void AddTeamToDirectory(DevTeam devTeam)
        {
            devTeam.DevTeamId = _devTeamIdCounter + 1;
            _devTeamsDirectory.Add(devTeam);
            _devTeamIdCounter++;
        }

        //DevTeam Read (all)
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeamsDirectory;
        }

        //DevTeam Read (one)
        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamById(int devTeamId)
        {
            foreach (DevTeam devTeam in _devTeamsDirectory)
            {
                if (devTeam.DevTeamId == devTeamId)
                {
                    return devTeam;
                }
            }
            return null;
        }

        //DevTeam Update

        public bool UpdateDevleoper(int devTeamId, string teamName)
        {
            DevTeam existingDevTeam = GetTeamById(devTeamId);
            if (existingDevTeam != null)
            {
                existingDevTeam.TeamName = teamName;
                return true;
            }
            return false;
        }


        //DevTeam Delete
        public bool RemoveTeamFromDirectory(int devTeamId)
        {
            DevTeam teamToUpdate = GetTeamById(devTeamId);
            if (_devTeamsDirectory.Remove(teamToUpdate))
            {
                return true;
            }
            return false;
        }

    }
}
