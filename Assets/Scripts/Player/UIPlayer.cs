using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
* UIPlayer change the UI in function of the Player data
*/
public class UIPlayer : MonoBehaviour {

    [Header("Body color")]
    [SerializeField]
    Color white;
    [SerializeField]
    Color black;
    [SerializeField]
    Color asian;
    [SerializeField]
    Color arab;
    [Header("Body image")]
    [SerializeField]
    Image hands;
    [SerializeField]
    Image legs;
    [SerializeField]
    Image head;

    // Use this for initialization
    void Start () {
        changeUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    *@brief : update the ui of the Player
    */
    void changeUI()
    {
        changeEthnieUI();
    }

    /*
    *@brief : update the ethine ui of the Player
    */
    void changeEthnieUI()
    {
        Color c = white;    // basic color
        if (GameManager.instance.getPlayer().getEthnie() == Player.ethnie.white)
        {
            c = white;
        }
        else if (GameManager.instance.getPlayer().getEthnie() == Player.ethnie.black)
        {
            c = black;
        }
        else if(GameManager.instance.getPlayer().getEthnie() == Player.ethnie.arab)
        {
            c = arab;
        }
        else if (GameManager.instance.getPlayer().getEthnie() == Player.ethnie.asian)
        {
            c = asian;
        }
        
        hands.color = c;
        legs.color = c;
        head.color = c;
    }
}
