using UnityEngine;
using UnityEngine.UI;

public class selection : MonoBehaviour {

    bool onPlay = true;
    bool onOptions = false;
    bool onQuit = false;
    public GameObject play;
    public GameObject options;
    public GameObject quit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            GameManager.instance.getAudioManager().selectsound.start();
            if (onPlay)
            {
                play.GetComponent<Image>().enabled = false;
                options.GetComponent<Image>().enabled = true;
                onPlay = false;
                onOptions = true;
            }
           else if(onOptions)
            {
                options.GetComponent<Image>().enabled = false;
                quit.GetComponent<Image>().enabled = true;
                onOptions = false;
                onQuit = true;
            }
            else if (onQuit)
            {
                quit.GetComponent<Image>().enabled = false;
                play.GetComponent<Image>().enabled = true;
                onQuit = false;
                onPlay = true;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Z)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GameManager.instance.getAudioManager().selectsound.start();
            if (onPlay)
            {
                play.GetComponent<Image>().enabled = false;
                quit.GetComponent<Image>().enabled = true;
                onPlay = false;
                onQuit = true;
            }
            else if (onOptions)
            {
                options.GetComponent<Image>().enabled = false;
                play.GetComponent<Image>().enabled = true;
                onOptions = false;
                onPlay = true;
            }
            else if (onQuit)
            {
                quit.GetComponent<Image>().enabled = false;
                options.GetComponent<Image>().enabled = true;
                onQuit = false;
                onOptions = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (onPlay)
            {
                GetComponentInParent<StartOptions>().StartButtonClicked();
                GameManager.instance.launchGame();
                gameObject.SetActive(false);
                onPlay = false;
                onOptions = false;
                onQuit = false;
            }
            else if (onOptions)
            {
                GetComponentInParent<ShowPanels>().ShowOptionsPanel();
            }
            else if (onQuit)
            {
                GetComponentInParent<QuitApplication>().Quit();
            }
        }
    }
}
