using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    bool collided = false;
    public float maxspeed = 10f;
    bool facingRight = true;
    public float maxfall = -20f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    Collider2D col;
    public float jumpForce = 700f;
    float timer = 0.0f;
    public float idleTime = 10.0f;

    Animator anim;

    void Start()
    {
        anim  = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (anim.GetFloat("speed") != 0)
        {
            timer = 0.0f;
        }
        timer += Time.deltaTime;
        //Debug.Log("timer = " + timer);
        if (timer > idleTime)
        {
            anim.SetBool("wait", true);
            timer = 0.0f;
        }
        else
        {
            anim.SetBool("wait", false);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            if (Input.GetAxis("Vertical") < 0 && collided)
            {
                //Debug.Log("je suis la !");
                StartCoroutine(wait1sec());
            }
            anim.SetBool("ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (!grounded && !Input.GetButton("Jump") && GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
        }

        if (GetComponent<Rigidbody2D>().velocity.y < maxfall)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, maxfall);
        }

        if( Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.gameObject.layer == LayerMask.NameToLayer("thin"))
        {
            collided = true;
            col = coll.collider;
            //Debug.Log("collided = " + collided);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.gameObject.layer == LayerMask.NameToLayer("thin"))
        {
            collided = false;
            //Debug.Log("collided = " + collided);
        }
    }

    IEnumerator wait1sec()
    {
        col.enabled = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        col.enabled = true;
    }
}
