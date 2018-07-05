using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "(Enter 'menu' to go back)";
    string[] level1Passwords;
    string[] level2Passwords;
    string[] level3Passwords;

    // Game state
    int level;
    int score = 0;
    int attempts;
    string username;
    string password;
    string extraHint;    // only for Level 3
    enum Screen { Startup, MainMenu, Password, Win, Lose };
    Screen currentScreen = Screen.Startup;

    public TextAsset level1PasswordFile;
    public TextAsset level2PasswordFile;
    public TextAsset level3PasswordFile;

    // Use this for initialization
    void Start ()
    {
        // Get words from text files and make each line an element
        level1Passwords = level1PasswordFile.text.Split('\n');
        level2Passwords = level2PasswordFile.text.Split('\n');
        level3Passwords = level3PasswordFile.text.Split('\n');

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
            if (input == "menu")
            {
                ShowMainMenu();
            }
            else
            {
                checkPassword(input);
            }
        }
        else if (currentScreen == Screen.Win || currentScreen == Screen.Lose)
        {
            if (input == "Y" || input == "y")
            {
                SetRandomPassword();
            }
            else if (input == "N" || input == "n")
            {
                ShowMainMenu();
            }
        }
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + username + " (Score: " + score + ")");
        Terminal.WriteLine("Choose a target to hack into:\n");
        Terminal.WriteLine("1: Server County Library (Easy)");
        Terminal.WriteLine("2: Dells Largo Bank (Medium)");
        Terminal.WriteLine("3: NSA (Hard)\n");
        Terminal.WriteLine("HS C:\\Users\\" + username + ">");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            SetRandomPassword();
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

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Enter your guess, hint: " + password.Anagram());
        if (level == 3)
        {
            Terminal.WriteLine("(" + extraHint + ")");
        }
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Infiltrating the Server County Library...");
                password = level1Passwords[Random.Range(0, level1Passwords.Length)].TrimEnd();
                attempts = 3;
                break;
            case 2:
                Terminal.WriteLine("Infiltrating Dells Largo Bank...");
                password = level2Passwords[Random.Range(0, level2Passwords.Length)].TrimEnd();
                attempts = 5;
                break;
            case 3:
                Terminal.WriteLine("Infiltrating the NSA...");
                // split the line in two by the '-'
                string[] line = level3Passwords[Random.Range(0, level3Passwords.Length)].Split('-');
                password = line[0];
                extraHint = line[1];
                attempts = 7;
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please unscramble the password.\n");
        AskForPassword();
    }

    void checkPassword(string input)
    {
        if (input == password)
        {
            score += 100 * attempts;
            DisplayWinScreen();
        }
        else
        {
            attempts--;
            if (attempts <= 0)
            {
                DisplayLoseScreen();
            }
            else
            {
                switch (level)
                {
                    case 1: score -= 50;
                        break;
                    case 2: score -= 100;
                        break;
                    case 3: score -= 150;
                        break;
                }
                Terminal.ClearScreen();
                Terminal.WriteLine("Sorry, you have " + attempts + " guess(es) remaining");
                AskForPassword();
            }
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Play Again? (Y/N)");
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1: Terminal.WriteLine("What overdue book? ;)");
                break;
            case 2: Terminal.WriteLine("Take as much as you like! >:D");
                break;
            case 3: Terminal.WriteLine("Plunge into the deep state!! :O");
                break;
            default: Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("\nGreat job! You score is now: " + score);
    }

    void DisplayLoseScreen()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        Terminal.WriteLine("The password was " + password);
        Terminal.WriteLine("Sorry, you've been locked out.");
        Terminal.WriteLine("Play Again? (Y/N)");
    }
}
