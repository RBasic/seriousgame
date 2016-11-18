using UnityEngine;
using System.Collections;

public class DiscoverRoom : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<GamasutraRoom>().discoverRoom(true);
        }
    }
}
