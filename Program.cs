using System;
using System.Collections.Generic;

class Command
{
    private Dictionary<string, Action<string>> commandMap;

    public Command()
    {
        InitializeCommandMap();
    }

    private void InitializeCommandMap()
    {
        commandMap = new Dictionary<string, Action<string>>();
        commandMap.Add("level", LoadLevel);
        commandMap.Add("exit", ExitGame);
    }

    public void ExecuteCommand(string command, string argument = null)
    {
        if (commandMap.ContainsKey(command.ToLower()))
        {
            commandMap[command.ToLower()](argument);
        }
        else
        {
            Console.WriteLine("Invalid Command");
        }
    }

    public void ExitGame()
    {
        Console.WriteLine("Exiting game...");
    }

    private string[] Levels = {
        "cake",
        "quad_torch",
        "thief_wan",
        "olof_meister",
    };

    public void LoadLevel(string levelName)
    {
        if (string.IsNullOrEmpty(levelName))
        {
            ListLevels();
        }
        else
        {
            if (Array.Exists(Levels, x => x.Equals(levelName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Loading level: {levelName}");
            }
            else
            {
                Console.WriteLine("Invalid level name");
            }
        }
    }

    private void ListLevels()
    {
        Console.WriteLine("Levels:\n");
        foreach (string levelName in Levels)
        {
            Console.WriteLine($"- {levelName}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Command commandHandler = new Command();

        commandHandler.ExecuteCommand("level", "quad_torch");
        // commandHandler.ExecuteCommand("level");
        // commandHandler.ExecuteCommand("level", "cake");
        // commandHandler.ExecuteCommand("exit");
        // commandHandler.ExecuteCommand("lol");
    }
}
