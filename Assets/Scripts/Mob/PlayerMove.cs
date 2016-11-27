using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private float speed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
