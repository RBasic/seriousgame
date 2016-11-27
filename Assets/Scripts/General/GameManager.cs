﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    private Player p;
    private GameObject currentRoom;

    [SerializeField] GameObject prefabEnemy;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
        p = new Player();
    }

    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

  
    /*
    *@brief : all the functions call when the player tap play
    */
    public void launchGame(){
        SaveLoad.Load();
        setPlayer();
    }

  

    /*
    * @brief : set the param of the player
    */
    public void setPlayer()
    {
        p.randomPlayer();
       // if(GameObject.Find("panelShowPerso")!=null)
       //     ScreenShots.instance.TakeHiResShot(GameObject.Find("panelShowPerso").GetComponent<RectTransform>());    // TO DO , enlever find pas beau, mettre un delay 
        SaveLoad.Save();
    }

    /*
   * @brief : get the player
   */
    public Player getPlayer()
    {
        return p;
    }

    public GameObject getPlayerGameObject()
    {
        return player;
    }

    public void setCurrentRoom(GameObject room)
    {
        currentRoom = room;
    }

    public GameObject getCurrentRoom()
    {
        return currentRoom;
    }

    public GameObject getPrefabEnemy()
    {
        return prefabEnemy;
    }

}
