using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public float speed = 0.5f;
    public float jumpSpeed = 20;
    public bool isGrounded = false;

    void Update(){
        transform.Translate(Input.GetAxis("Horizontal")*speed, 0, 0);
        if (Input.GetButtonDown("Jump")&&(isGrounded)){
            Debug.Log("Je jump !");
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision ! "+isGrounded);
        if (col.gameObject.name == "sol")
        {
            isGrounded = true;
        }
    }
}
