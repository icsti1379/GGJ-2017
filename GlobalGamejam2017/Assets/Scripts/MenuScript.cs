﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//NOTE: If event handler is used add ", IPointerClickHandler" after MonoBehaviour!
public class MenuScript : MonoBehaviour
{
    //TODO: Before finish delete all debug comments!

    /// <summary>
    /// Enum of all menu states.
    /// </summary>
    public enum MenuStates
    {
        Main,
        Player,
        Options,
        Help,
        Credits,
        Exit
    }

    #region variables

    // Variable for define current state.
    public MenuStates currentState;

    // Menu panel objects as GameObjects.
    public GameObject mainMenu;
    public GameObject playerMenu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public GameObject creditsMenu;
    //TODO: Uncomment this if application exit in MenuState.Exit works!
    //public GameObject exitMenu;

    #endregion
    
    
    /// <summary>
    /// Initialize any variables or game states before the game starts.
    /// Is called only once during the lifetime of the script instance.
    /// </summary>
    void Awake()
    {
        // Always sets first state to main menu
        currentState = MenuStates.Main;
    }


    /// <summary>
    /// Update is called every frame.
    /// Checks menu state every frame.
    /// </summary>
    void Update()
    {
        //TODO: Refactor hard coded SetActive check?
        //TODO: Is exitMenu needed?
        // Checks current menu state
        switch (currentState)
        {
                case MenuStates.Main:
                    // Sets active gameobject for main menu
                    mainMenu.SetActive(true);
                    playerMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                    break;

                case MenuStates.Player:
                    // Sets active gameobject for player menu
                    playerMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                    break;

            case MenuStates.Options:
                    // Sets active gameobject for options menu
                    optionsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    playerMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                    break;

                case MenuStates.Help:
                    // Sets active gameobject for options menu
                    helpMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    playerMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    creditsMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                break;

                case MenuStates.Credits:
                    // Sets active gameobject for options menu
                    creditsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    playerMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    helpMenu.SetActive(false);
                    //exitMenu.SetActive(false);
                break;

                //TODO: CHECK IF THIS IS CORRECT ?!
                //case MenuStates.Exit:
                //    //Exits game
                //    //mainMenu.SetActive(false);
                //    //playerMenu.SetActive(false);
                //    //optionsMenu.SetActive(false);
                //    //helpMenu.SetActive(false);
                //    //creditsMenu.SetActive(false);
                //    //exitMenu.SetActive(true);
                //    Application.Quit();
                //break;
        }
    }

    #region Buttons

    /// <summary>
    /// Interaction with start button.
    /// Changes current state to playerMenu.
    /// </summary>
    public void OnStartGame()
    {
        // Log activity
        Debug.Log("You pressed start game!");

        //TODO: If LoadScene is being used delete this.
        currentState = MenuStates.Player;

        //TODO: Uncomment this if player selection after start is not needed and is implemented else.
        // Add load level for new scene here.
        // SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// Interaction with play button.
    /// Loads game scene.
    /// </summary>
    public void OnPlayGame()
    {
        // Log activity
        Debug.Log("You pressed Let's play!");

        // Add load level for new scene here.
        SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// Interaction with options button.
    /// Change current state to optionsMenu.
    /// </summary>
    public void OnOptions()
    {
        // Log activity
        Debug.Log("You've clicked options.");

        // Change menu state
        currentState = MenuStates.Options;
    }

    /// <summary>
    /// Interaction with windowed button in options.
    /// Switch screen mode windowed or fullscreen.
    /// NUR ALS BEISPIELFUNKTION!
    /// </summary>
    public void OnWindowedMode()
    {
        // Log activity
        Debug.Log("You want to play in windowed mode.");

        // Change screen resolution to windowed/fullscreen
        //TODO: Add screen resolution modify here.
        //NOTE: Kann auch irgendeine andere Funktion sein. Ist nur als Platzhalter da.
    }

    /// <summary>
    /// Interaction with back button.
    /// Changes current state to mainMenu.
    /// Back button is in every submenue except on "Start" and "Exit".
    /// </summary>
    public void OnBackToMenu()
    {
        // Log activity
        Debug.Log("Go back to main menu.");

        // Change menu state
        currentState = MenuStates.Main;
    }

    /// <summary>
    /// Interaction with help button.
    /// Changes current state to helpMenu.
    /// </summary>
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

    #endregion

    // If needed for event handling
    #region EventHandler

    //NOTE: ClickHandler maybe for exit application?! -> Just mouse ...
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        Application.Quit();
    //    }
    //}

    #endregion
}