using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Use this for initialization
	void Start () {
        string name = "Jules";
        ShowMainMenu(name);
    }

    void ShowMainMenu (string aName) {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + aName);
        Terminal.WriteLine("Choose a target to hack into:\n");
        Terminal.WriteLine("Press 1 for Server County Library");
        Terminal.WriteLine("Press 2 for Dells Largo Bank");
        Terminal.WriteLine("Press 3 for the NSA\n");
        Terminal.WriteLine("HS C:\\Users\\" + aName + ">");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
