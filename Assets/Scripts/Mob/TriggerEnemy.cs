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
	void Update ()
    {
        transform.position = new Vector2(transform.position.x, _enemy.transform.position.y + 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _enemy)
            if(_enemy.GetComponent<EnemyPathing>().getPathing())
                _enemy.GetComponent<EnemyPathing>().Flip();
    }
}
