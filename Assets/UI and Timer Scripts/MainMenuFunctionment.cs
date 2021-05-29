/*
    Author: Rodrigo Quiroz Reyes
    Edited by: Lorenzo Jácome Ceniceros and Mr. Spikes
    February 29, 2020
    Description: This scripts controls functionment from the Main Menu and Options/Setting Area of the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctionment : MonoBehaviour
{
    //Definition of Main Menu Components and settingss area components 
    public GameObject optionsMenu;

    public GameObject mainMenuButtons;
    public GameObject mainMenuPanel;

    public GameObject nivelesMenu;
    public GameObject settingsMenu;
    public GameObject credits;
    public GameObject informationL1;
    public GameObject informationL2;
    public GameObject informationL3;
    public GameObject informationL4;


    //Boolean variable for controls' pannel apperance
    public bool controlsApperance;

    void Start(){
        
    }
    public void Awake()
    {

        controlsApperance = false;
    }
    
    public void Update()
    {
        if(!controlsApperance)
        {
            optionsMenu.SetActive(false);
        }

    }

    public void OpenOptionsSettings() //Tutorial area is opened
    {
        mainMenuButtons.SetActive(false);
        optionsMenu.SetActive(true); //Tutorial
        settingsMenu.SetActive(false);
        informationL1.SetActive(false);
        controlsApperance = true; 
    }

    public void ReturnMainMenu() //Players return to Main Menu
    {
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        informationL1.SetActive(false);
        informationL2.SetActive(false);
        informationL3.SetActive(false);
        informationL4.SetActive(false);
        mainMenuButtons.SetActive(true);
        credits.SetActive(false);
        controlsApperance = false;
    }

    public void OpenSettings() //Settings area is open.
    {
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(true);
        mainMenuButtons.SetActive(false);
        credits.SetActive(false);
        informationL1.SetActive(false);
        controlsApperance = true;
    }

    public void OpenCredits() {

        credits.SetActive(true);
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(false);
        informationL1.SetActive(false);
        controlsApperance = true;

    }
    public void openinformationL1()
    {

        informationL1.SetActive(true);
        credits.SetActive(false);
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(false);
        controlsApperance = true;

    }
    public void openinformationL2()
    {

        informationL2.SetActive(true);
        credits.SetActive(false);
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(false);
        controlsApperance = true;

    }
    public void openinformationL3()
    {

        informationL3.SetActive(true);
        credits.SetActive(false);
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(false);
        controlsApperance = true;

    }
    public void openinformationL4()
    {

        informationL4.SetActive(true);
        credits.SetActive(false);
        nivelesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(false);
        controlsApperance = true;

    }

    public void jugar() 
    {
        nivelesMenu.SetActive(true);
        informationL1.SetActive(false);
        mainMenuButtons.SetActive(false);
        informationL2.SetActive(false);
        informationL3.SetActive(false);
        informationL4.SetActive(false);
        controlsApperance = false;
    }

    public void level1() 
    {
        SceneManager.LoadScene("Nivel 1");

    }
    public void level2() 
    {
        SceneManager.LoadScene("Nivel 2");

    }
    public void level3() 
    {
        SceneManager.LoadScene("Nivel 3");

    }

    public void level4() 
    {
        SceneManager.LoadScene("Nivel 4");

    }
    
    /*public void exitGame() 
    {
        if(UnityEditor.EditorApplication.isPlaying){
            UnityEditor.EditorApplication.isPlaying=false;
        }
        else
        Application.Quit();

    } */

   
}