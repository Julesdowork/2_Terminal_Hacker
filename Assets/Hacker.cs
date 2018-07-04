using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "(Enter 'menu' to go back)";
    string[] level1Passwords;
    string[] level2Passwords;
    string[] level3Passwords;

    // Game state
    int level;
    string username;
    string password;
    string extraHint;    // only for Level 3
    enum Screen { Startup, MainMenu, Password, Win };
    Screen currentScreen = Screen.Startup;

    public TextAsset level1PasswordFile;
    public TextAsset level2PasswordFile;
    public TextAsset level3PasswordFile;

    // Use this for initialization
    void Start ()
    {
        level1Passwords = level1PasswordFile.text.Split('\n');
        level2Passwords = level2PasswordFile.text.Split('\n');
        level3Passwords = level3PasswordFile.text.Split('\n');
        foreach (string line in level3Passwords)

        username = "";
        Terminal.WriteLine("Please enter your username:");
        print(level3Passwords[0]);
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
        else
        {
            if (input == "menu")
            {
                ShowMainMenu();
            }
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
            AskForPassword();
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
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        if (level == 3)
        {
            Terminal.WriteLine("(" + extraHint + ")");
        }
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Infiltrating the Server County Library...");
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                Terminal.WriteLine("Infiltrating Dells Largo Bank...");
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                Terminal.WriteLine("Infiltrating the NSA...");
                string[] line = level3Passwords[Random.Range(0, level3Passwords.Length)].Split('-');
                password = line[0];
                extraHint = line[1];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void checkPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1: Terminal.WriteLine("What overdue book? ;)");
                Terminal.WriteLine(@"
     _________
    /       //
   /       //
  /______ //
 (_______(/
"
                );
                break;
            case 2: Terminal.WriteLine("Take as much as you like! >:D");
                Terminal.WriteLine(@"
 ---------------------
 | |=====   |======  |
 | |     \  ||       |
 | |      ) |=====   |
 | |     /  ||       |
 | |=====   ||       |
 ---------------------
"
                );
                break;
            case 3: Terminal.WriteLine("Plunge into the deep state!! :O");
                Terminal.WriteLine(@"
         _
   nnn  < \    nnn
  |  /__/  \__/   |
  |    =======    |
  |    \     /    |
   \    \___/    /
    \  /|| ||\  /  ____
	 \/ || || \/  (    )
 ================(      )
 ||  ||           (____)
"
                );
                break;
            default: Debug.LogError("Invalid level number");
                break;
        }
    }
}
