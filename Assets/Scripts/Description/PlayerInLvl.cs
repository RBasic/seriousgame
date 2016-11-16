using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInLvl : MonoBehaviour {

    /*
*@brief : laucnh the game when the player go in the roms
*/
    public void playerInRooms()
    {
        SceneManager.LoadScene("RoomGeneration");
    }
}
