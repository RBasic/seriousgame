using UnityEngine;
using System.Collections;

public class TriggerEnemy : MonoBehaviour {

    GameObject _enemy;

	// Use this for initialization
	void Start ()
    {
        _enemy = gameObject.transform.parent.GetChild(0).gameObject;         
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _enemy)
            if(_enemy.GetComponent<EnemyPathing>().getPathing())
                _enemy.GetComponent<EnemyPathing>().Flip();
    }
}
