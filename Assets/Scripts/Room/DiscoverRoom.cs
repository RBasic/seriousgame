using UnityEngine;
using System.Collections;

/*discover room and get the current room*/
public class DiscoverRoom : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<GamasutraRoom>().discoverRoom(true);
            //other.gameObject.GetComponent<Player>().setCurrentRoom(this.gameObject.GetComponentInParent<GamasutraRoom>().gameObject);
            GameManager.instance.setCurrentRoom(this.gameObject.GetComponentInParent<GamasutraRoom>().gameObject);
        }
    }
}
