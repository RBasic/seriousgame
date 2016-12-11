using UnityEngine;
using System.Collections;

public class MoneyTrigger : MonoBehaviour {

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
            GameManager.instance.addCoin(nb);
            Destroy(this.gameObject);
        }
    }
}
