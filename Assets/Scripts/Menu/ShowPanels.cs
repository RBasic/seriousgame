using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 


	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
        GameManager.instance.getAudioManager().selectsound.start();
        optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        GameManager.instance.getAudioManager().selectsound.start();
        optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
    {
        GameManager.instance.getAudioManager().selectsound.start();
        menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
    {
        GameManager.instance.getAudioManager().selectsound.start();
        menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
    {
        GameManager.instance.getAudioManager().selectsound.start();
        pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
    {
        GameManager.instance.getAudioManager().selectsound.start();
        pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}
}
