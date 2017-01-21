using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour, IPointerClickHandler
{
    // Menu states
    public enum MenuStates
    {
        Main,
        Options,
        Help,
        Credits
        //Exit
    }

    public MenuStates currentState;

    // Menu panel objects
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public GameObject creditsMenu;
    //TODO: Uncomment this if application exit in MenuState.Exit works!
    //public GameObject exitMenu;

    // When script first starts
    void Awake()
    {
        // Always sets first menu to main menu
        currentState = MenuStates.Main;
    }

    

    // Update menu state
    void Update()
    {
        // Checks current menu state
        switch (currentState)
        {
                case MenuStates.Main:
                    //Sets active gameobject for main menu
                    mainMenu.SetActive(true);
                    optionsMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    break;

                case MenuStates.Options:
                    //Sets active gameobject for options menu
                    optionsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    break;

                case MenuStates.Help:
                    //Sets active gameobject for options menu
                    helpMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                break;

                case MenuStates.Credits:
                    //Sets active gameobject for options menu
                    creditsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    helpMenu.SetActive(false);
                break;

                //TODO: CHECK IF THIS IS CORRECT ?!
                //case MenuStates.Exit:
                //    //Exits game
                //    //mainMenu.SetActive(false);
                //    //optionsMenu.SetActive(false);
                //    //helpMenu.SetActive(false);
                //    //creditsMenu.SetActive(false);
                //    //exitMenu.SetActive(true);
                //    Application.Quit();
                //break;
        }
    }

    // When start button is pressed
    public void OnStartGame()
    {
        // Log activity
        Debug.Log("You pressed start game!");

        // Add load level for new scene here.
    }

    // When options button is pressed
    public void OnOptions()
    {
        // Log activity
        Debug.Log("You've clicked options.");

        // Change menu state
        currentState = MenuStates.Options;
    }

    public void OnWindowedMode()
    {
        // Log activity
        Debug.Log("You want to play in windowed mode.");

        // Change screen resolution to windowed/fullscreen
    }

    public void OnBackToMenu()
    {
        // Log activity
        Debug.Log("Go back to main menu.");

        // Change menu state
        currentState = MenuStates.Main;
    }

    public void OnHelp()
    {
        // Log activity
        Debug.Log("Help button clicked.");

        // Change menu state
        currentState = MenuStates.Help;
    }

    public void OnCredits()
    {
        // Log activity
        Debug.Log("Credits button clicked.");

        // Change menu state
        currentState = MenuStates.Credits;
    }

    public void OnExit()
    {
        // Log activity
        Debug.Log("Ext button clicked.");

        Application.Quit();

        //TODO: Menu state or just Application.Quit() ??
        // Change menu state
        //currentState = MenuStates.Exit;
    }

    //NOTE: ClickHandler maybe for exit application?! -> Just mouse ...
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Application.Quit();
        }
    }
}