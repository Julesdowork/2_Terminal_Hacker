using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "age", "bloom", "cradle", "dentist", "edge" };
    string[] level2Passwords = { "flair", "gullible", "humane", "incense", "jurisdiction" };
    string[] level3Passwords = { "labyrinthine", "melodramatic", "notoriety", "ominous", "pulchritude" };

    // Game state
    int level;
    string username;
    string password;
    enum Screen { Startup, MainMenu, Password, Win };
    Screen currentScreen = Screen.Startup;

    // Use this for initialization
	void Start ()
    {
        username = "";
        Terminal.WriteLine("Please enter your username:");
    }
    
    void OnUserInput (string input)
    {
        if (currentScreen == Screen.Startup)
        {
            username = input;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + username);
        Terminal.WriteLine("Choose a target to hack into:\n");
        Terminal.WriteLine("Press 1 for Server County Library");
        Terminal.WriteLine("Press 2 for Dells Largo Bank");
        Terminal.WriteLine("Press 3 for the NSA\n");
        Terminal.WriteLine("HS C:\\Users\\" + username + ">");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "tahiti")
        {
            Terminal.WriteLine("It's a magical place...");
        }
        else if (input == "hakuna matata")
        {
            Terminal.WriteLine("What a wonderful phrase!");
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome back, Mr. Bond.");
        }
        else if (input == "shutdown")
        {
            Terminal.WriteLine("...");
            Terminal.WriteLine("I'm sorry.");
            Terminal.WriteLine("I'm afraid I can't do that...");
        }
        else if (input == "westworld")
        {
            Terminal.WriteLine("These violent delights ");
            Terminal.WriteLine("have violent ends");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid command.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        int index;
        switch (level)
        {
            case 1: Terminal.WriteLine("Infiltrating the Server County Library...");
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2: Terminal.WriteLine("Infiltrating Dells Largo Bank...");
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3: Terminal.WriteLine("Infiltrating the NSA...");
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default: Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password:");
    }

    void checkPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("You got it!");
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("Sorry, that's wrong.");
        }
    }
}
