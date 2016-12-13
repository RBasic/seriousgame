using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Marchand : MonoBehaviour {

    [SerializeField]
    Image spriteSmall;
    [SerializeField]
    Image spriteMedium;
    [SerializeField]
    Image spriteBig;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void load()
    {
        string path = "marchand/";
        path += GameManager.instance.getPlayer().getEthnie().ToString();
        Debug.Log("PATH SPRITE MARCHAND: " + path);
        spriteSmall.sprite = Resources.Load(path+"/small") as Sprite;
        spriteMedium.sprite = Resources.Load(path+"/medium") as Sprite;
        spriteBig.sprite = Resources.Load(path+"/big") as Sprite;
    }

    public Image getSpriteSmall() { return spriteSmall; }
    public Image getSpriteMedium() { return spriteMedium; }
    public Image getSpriteBig() { return spriteBig; }
}
