using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        public string Name { get; set; }
        private List<Player> players = new List<Player>();
        public List<Player> Players => players;

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var playerToRemove = players.Find(p => p.Name == playerName);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
            }
        }

        public string GetTeamHistory()
        {
            string history = $"Team {Name} was created on {DateTime.Now}\n";
            foreach (var player in players)
            {
                history += $"Player {player.Name} added as {player.Position}\n";
            }
            return history;
        }
    }
}
