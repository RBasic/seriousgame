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
        if (rand == 4)
        {
            transform.localPosition = new Vector3(1.87f, -0.87f, 0.14f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -64.26701f);
        }
        else if (rand == 3)
        {
            transform.localPosition = new Vector3(2.34f, -1.62f, 0.14f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -64.26701f);
        }
        else if (rand == 2)
        {
            transform.localPosition = new Vector3(1.54f, -1.14f, 0.14f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -63.915f);
        }
        else if (rand == 1)
        {
            transform.localPosition = new Vector3(2.01f, -0.83f, 0.14f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -54.5f);
        }
        else
        {
            transform.localPosition = new Vector3(1.54f, -1.14f, 0.14f);
            transform.localRotation = Quaternion.Euler(0.0f,0.0f, -63.915f);

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
