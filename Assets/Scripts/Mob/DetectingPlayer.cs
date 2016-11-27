using UnityEngine;
using System.Collections;

public class DetectingPlayer : MonoBehaviour {

    GameObject enemy;

	// Use this for initialization
	void Start ()
    {
	    enemy = gameObject.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            enemy.GetComponent<EnemyPathing>().setChasingPlayer(true);
            enemy.GetComponent<EnemyPathing>().setPathing(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.GetComponent<EnemyPathing>().startSpeedBoostCoroutine();
            //enemy.GetComponent<EnemyPathing>().setChasingPlayer(false);
        }
    }
}
