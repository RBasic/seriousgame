using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInLvl : MonoBehaviour {

    /*
*@brief : laucnh the game when the player go in the rooms
*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.instance.getAudioManager().playsound.start();
            playerInRooms();
        }
    }

    public void playerInRooms()
    {
        GameManager.instance.getAudioManager().releaseAll();
        GameManager.instance.getAudioManager().playsound.start();
        SceneManager.LoadScene("RoomGeneration");
        GameManager.instance.getPanelLife().SetActive(true);
        GameManager.instance.getUI().GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
