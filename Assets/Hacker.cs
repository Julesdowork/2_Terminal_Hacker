using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    private string name;

    // Use this for initialization
	void Start ()
    {
        name = "Jules";
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("Choose a target to hack into:\n");
        Terminal.WriteLine("Press 1 for Server County Library");
        Terminal.WriteLine("Press 2 for Dells Largo Bank");
        Terminal.WriteLine("Press 3 for the NSA\n");
        Terminal.WriteLine("HS C:\\Users\\" + name + ">");
    }

    void OnUserInput (string input)
    {
        if (input == "1")
        {
            Terminal.WriteLine("You chose Server County Library");
        }
        else if (input == "2")
        {
            Terminal.WriteLine("You chose Dells Largo Bank");
        }
        else if (input == "3")
        {
            Terminal.WriteLine("You chose the NSA");
        }
        else if (input == "menu")
        {
            ShowMainMenu();
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
}
