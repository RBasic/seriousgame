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
            playerInRooms();
        }
    }

    public void playerInRooms()
    {
        SceneManager.LoadScene("RoomGeneration");
        GameManager.instance.getPanelLife().SetActive(true);
        GameManager.instance.getAudioManager().LaunchTheme();
    }
}
