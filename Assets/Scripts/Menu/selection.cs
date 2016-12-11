using UnityEngine;
using System.Collections;

public class selection : MonoBehaviour {

    bool onPlay = true;
    bool onOptions = false;
    bool onQuit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (onPlay)
            {
                transform.position = new Vector3(transform.position.x, -2.8f, 0);
                onPlay = false;
                onOptions = true;
            }
           else if(onOptions)
            {
                transform.position = new Vector3(transform.position.x, -3.5f, 0);
                onOptions = false;
                onQuit = true;
            }
            else if (onQuit)
            {
                transform.position = new Vector3(transform.position.x, -1.9f, 0);
                onQuit = false;
                onPlay = true;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Z)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (onPlay)
            {
                transform.position = new Vector3(transform.position.x, -3.5f, 0);
                onPlay = false;
                onQuit = true;
            }
            else if (onOptions)
            {
                transform.position = new Vector3(transform.position.x, -1.9f, 0);
                onOptions = false;
                onPlay = true;
            }
            else if (onQuit)
            {
                transform.position = new Vector3(transform.position.x, -2.8f, 0);
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
