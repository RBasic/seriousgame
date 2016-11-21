using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float maxspeed = 10f;
    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;
    float timer = 0.0f;
    public float idleTime = 10.0f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
    }

    void Update()
    {
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
            anim.SetBool("ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if(!grounded && !Input.GetButton("Jump") && GetComponent<Rigidbody2D>().velocity.y>-5)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
        }
        anim.SetFloat("wait", Time.deltaTime);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
