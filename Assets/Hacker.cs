using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    private string name = "Jules";

	// Use this for initialization
	void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu () {
        Terminal.ClearScreen();
        string greeting = "Hello " + name;
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Choose a target to hack into:\n");
        Terminal.WriteLine("Press 1 for Server County Library");
        Terminal.WriteLine("Press 2 for Dells Largo Bank");
        Terminal.WriteLine("Press 3 for the NSA\n");
        Terminal.WriteLine("HS C:\\Users\\" + name + ">");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
