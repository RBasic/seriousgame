using UnityEngine;
using System.Collections;

public class MoneyTrigger : MonoBehaviour {

    [FMODUnity.EventRef]

    public string money = "event:/Serious Game/FX/Money";
    FMOD.Studio.EventInstance m;

    void Start()
    {

        m = FMODUnity.RuntimeManager.CreateInstance(money);
    }
    public void Money()
    {
        m.start();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            int nb = 10;
            if(!GameManager.instance.getPlayer().getGender())
            {
                nb = 8;
            }
            else if(GameManager.instance.getPlayer().getEthnie().ToString() == "arab")
            {
                nb = 12;
            }
            Money();
            GameManager.instance.addCoin(nb);
            Destroy(this.gameObject);
        }
    }
}
