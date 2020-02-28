using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win };

    // member variables
    private readonly string currentUser = "Jerel";
    private short level;
    private Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu(currentUser);
    }

    // OnUserInput is called when the user enters a value
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            print($"the user typed: menu");
            ShowMainMenu(currentUser);
        } else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    private void RunMainMenu(string input)
    {
        switch (short.TryParse(input, out _))
        {
            case true when input == "1":
                print($"the user typed: 1");
                this.level = 1;
                StartGame();
                break;
            case true when input == "2":
                print($"the user typed: 2");
                this.level = 2;
                StartGame();
                break;
            case true when input == "3":
                print($"the user typed: 3");
                this.level = 3;
                StartGame();
                break;
            case true when input == "007":
                print($"the user selected a special value");
                Terminal.WriteLine("Please select a level, Mr. Bond!");
                break;
            case false when input == "menu":
                print($"the user typed: menu");
                ShowMainMenu(currentUser);
                break;
            default:
                print("value of input is " + input);
                print("value of case is " + short.TryParse(input, out _));
                print("invalid entry");
                Terminal.WriteLine("Please choose a valid option.");
                break;
        }
    }

    // ShowMainMenu clears the screen and writes the main menu to the Terminal
    private void ShowMainMenu(string username)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Greetings, {username}");
        Terminal.WriteLine("What spellbook would you like to read?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the Apprentice Scrolls");
        Terminal.WriteLine("Press 2 for the Wizard's spellbook");
        Terminal.WriteLine("Press 3 for the Archmage's Tome");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine($"You have chosen level {level}");
        Terminal.WriteLine($"Please enter your password: ");
    }
}
