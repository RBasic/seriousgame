using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class randomWeapon : MonoBehaviour {

    public List<Sprite> weapons;
    // Use this for initialization
    void Start () {
        int rand = Random.Range(0, weapons.Count);
        GetComponent<SpriteRenderer>().sprite = weapons[rand];
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<PolygonCollider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
