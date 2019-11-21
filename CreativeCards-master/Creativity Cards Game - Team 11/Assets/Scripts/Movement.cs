using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public bool jumped = false;
    public Animator animator;

    [SerializeField]
    private float maxSpeed;
    private Rigidbody2D rb;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // defines player's axis
        
        animator.SetFloat("MoveSpeed", Mathf.Abs(moveHorizontal)); //makes player animate

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if ((Input.GetKeyDown(KeyCode.W)) & (!jumped))  //makes player jump
        {
            jumped = true;
            rb.AddForce(jump, ForceMode2D.Impulse);
            //Debug.Log("jumped");
            animator.SetBool("IsJumping", true);
        }

        LimitSpeed();
    }

    private void LimitSpeed()
    {
        //https://answers.unity.com/questions/265810/limiting-rigidbody-speed.html
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    /*private void Flip(float moveHorizontal)   //don't uncomment this unless you want to flip and fix the gun sprite as well
    {
        if(moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }*/

    void FixedUpdate()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumped = false;
            animator.SetBool("IsJumping", false);
            //Debug.Log("ground hit");
        }

        if (other.gameObject.tag == "Platform")
        {
            jumped = false;
            animator.SetBool("IsJumping", false);
            //Debug.Log("platform hit");
        }

        //Debug.Log("object hit");
    }

    

}