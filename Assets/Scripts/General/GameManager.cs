using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    private Player p;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
        p = player.GetComponent<Player>();
    }

    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    // Use this for initialization
    void Start()
    {
       
       
    }
    /*
    *@brief : all the functions call when the player tap play
    */
    public void launchGame(){
        
        SaveLoad.Load();
        setPlayer();
    }

  
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            p.dead();
        }
      */
    
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




}
