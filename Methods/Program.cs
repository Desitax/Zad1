using Methods;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>(); 
        List<Player> players = new List<Player>();  
        string command = Console.ReadLine();
        string[] input= command.Split(' ');
        while (command != "exit")
        {
            try
            {
                switch (input[0])
                {
                    case "create_team":
                       
                        string teamName = input[1];
                        if (teams.Exists(x => x.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} already exists.");
                        }
                        else
                        {
                            teams.Add(new Team(teamName));
                            Console.WriteLine($"Team {teamName} created successfully.");
                        }
                        break;
                    case "create_player":
                    
                        string playerName = input[1];
                        string position = input[2];
                        if (players.Exists(p => p.Name == playerName))
                        {
                            Console.WriteLine($"Player {playerName} already exists.");
                        }
                        else
                        {
                            players.Add(new Player(playerName, position));
                            Console.WriteLine($"Player {playerName} with position {position} created.");
                        }
                        break;

                    case "add_player":
                        string teamToAddTo = input[1];
                        string playerToAdd = input[2];
                        Team team = teams.Find(t => t.Name == teamToAddTo);
                        Player player = players.Find(p => p.Name == playerToAdd);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamToAddTo} not found.");
                        }
                        else if (player == null)
                        {
                            Console.WriteLine($"Player {playerToAdd} not found.");
                        }
                        else
                        {
                            team.AddPlayer(player);
                            Console.WriteLine($"Player {playerToAdd} added to team {teamToAddTo}.");
                        }
                        break;

                    case "remove_player":
                        string teamToRemoveFrom = input[1];
                        string playerToRemove = input[2];
                        Team teamToRemove = teams.Find(t => t.Name == teamToRemoveFrom);

                        if (teamToRemove == null)
                        {
                            Console.WriteLine($"Team {teamToRemoveFrom} not found.");
                        }
                        else
                        {
                            teamToRemove.RemovePlayer(playerToRemove);
                            Console.WriteLine($"Player {playerToRemove} removed from team {teamToRemoveFrom}.");
                        }
                        break;

                    case "print_team":
                        string teamNameToPrint = input[1];
                        string filePath = input[2];
                        string logType = input[3];

                        Team teamToPrint = teams.Find(t => t.Name == teamNameToPrint);

                        if (teamToPrint != null)
                        {
                            if (input[4] == "txt")
                            {
                                ILog log = new TxtLog("../../../Files/print_team.txt");
                                log.Log(teamToPrint.GetTeamHistory());
                                Console.WriteLine($"History of team {teamNameToPrint} saved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamNameToPrint} not found.");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
