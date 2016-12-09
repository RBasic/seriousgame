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
    [Header("Body Woman Image")]
    [SerializeField]
    Image armW;
    [SerializeField]
    Image legW;
    [SerializeField]
    Image headW;
    [SerializeField]
    Image hairW;
    [SerializeField]
    Image bodyW;
    [SerializeField]
    Image footW;
    [Header("Body Men Image")]
    [SerializeField]
    Image armM;
    [SerializeField]
    Image legM;
    [SerializeField]
    Image headM;
    [SerializeField]
    Image hairM;
    [SerializeField]
    Image bodyM;
    [SerializeField]
    Image footM;

    // if it's the principal player or a one from the list
    [SerializeField] private bool UIcurrentPlayer;

     private   Color c ;    // basic color

    // Use this for initialization
    void Start () {
        c = white;  // basic color
        if (UIcurrentPlayer)
        {
            changeUI(GameManager.instance.getPlayer().getGender(), GameManager.instance.getPlayer().getEthnie());
        }
	}

    /*
    *@brief : update the ui of the Player
    */
    public void changeUI(bool sexuality, Player.ethnie e)
    {
        resetUI();
      
     
        if (sexuality){
            changeEthnieUI(e, armM);
            changeEthnieUI(e, headM);
            this.legM.gameObject.SetActive(true);
            this.hairM.gameObject.SetActive(true);
            this.bodyM.gameObject.SetActive(true);
            if (GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>() != null)
            {
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeChest(bodyM.GetComponent<Image>().sprite);
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeHair(hairM.GetComponent<Image>().sprite);
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeHead(headM.GetComponent<Image>().sprite);
            }
        }
        else
        {
            changeEthnieUI(e, armW);
            changeEthnieUI(e, headW);
            this.legW.gameObject.SetActive(true);
            this.hairW.gameObject.SetActive(true);
            this.bodyW.gameObject.SetActive(true);
            if (GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>() != null)
            {
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeChest(bodyW.GetComponent<Image>().sprite);
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeHair(hairW.GetComponent<Image>().sprite);
                GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeHead(headW.GetComponent<Image>().sprite);
            }
        }

        // change on the player
        if (GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>() != null)
        {
            GameManager.instance.getPlayerGameObject().GetComponent<SkinPlayer>().changeSkinColor(c);
        }

    }

    public void resetUI()
    {
        this.legW.gameObject.SetActive(false);
        this.hairW.gameObject.SetActive(false);
        this.bodyW.gameObject.SetActive(false);
        this.armW.gameObject.SetActive(false);
        this.headW.gameObject.SetActive(false);
        this.legM.gameObject.SetActive(false);
        this.hairM.gameObject.SetActive(false);
        this.bodyM.gameObject.SetActive(false);
        this.armM.gameObject.SetActive(false);
        this.headM.gameObject.SetActive(false);
    }

    /*
    *@brief : update the ethine ui of the Player
    */
    public void changeEthnieUI(Player.ethnie e,Image im)
    {
        if ( e== Player.ethnie.white)
        {
            c = white;
        }
        else if (e == Player.ethnie.black)
        {
            c = black;
        }
        else if(e== Player.ethnie.arab)
        {
            c = arab;
        }
        else if (e == Player.ethnie.asian)
        {
            c = asian;
        }
        im.gameObject.SetActive(true);
        im.color = c;
    }

    
   
}
