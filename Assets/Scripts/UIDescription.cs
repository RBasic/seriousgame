using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDescription : MonoBehaviour {

    [SerializeField] Text ethnie;
    [SerializeField] Text body;
    [SerializeField] Text handicap;
    [SerializeField] Text sexuality;
    [SerializeField] Text gender;

    // Use this for initialization
    void Start () {
        updateUIDescription();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    *@brief : update the ui of the description panel
    */
    void updateUIDescription()
    {
        updateUIType();
        updateUIBonusMalus();
    }

    /*
   *@brief : update the ui of the types
   */
    void updateUIType()
    {
        ethnie.text = GameManager.instance.getPlayer().getEthnieString();
        body.text = GameManager.instance.getPlayer().getBodyString();
        handicap.text = GameManager.instance.getPlayer().getHandicapString();
        sexuality.text = GameManager.instance.getPlayer().getSexualityString();
        gender.text = GameManager.instance.getPlayer().getGenderString();
    }

    /*
   *@brief : update the ui of the bonus/malus from type
   */
    void updateUIBonusMalus()
    {
       
    }

}
