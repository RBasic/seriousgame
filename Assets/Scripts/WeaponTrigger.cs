using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour {

    public GameObject coin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnColliderEnter2D(Collider2D other)
    {
        Debug.Log("Je suis la ");
        if(other.tag == "Enemy")
        {
            Instantiate(coin, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
