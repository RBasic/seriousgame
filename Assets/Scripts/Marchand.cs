using UnityEngine;
using System.Collections;

public class Marchand : MonoBehaviour {

    [SerializeField]
    Sprite spriteSmall;
    [SerializeField]
    Sprite spriteMedium;
    [SerializeField]
    Sprite spriteBig;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void load()
    {
        string path = "marchand/";
        path += GameManager.instance.getPlayer().getEthnie().ToString();
        spriteSmall = Resources.Load(path+"/small") as Sprite;
        spriteMedium = Resources.Load(path+"/medium") as Sprite;
        spriteBig = Resources.Load(path+"/big") as Sprite;
    }
}
