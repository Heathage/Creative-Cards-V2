using System.Collections;
using System;
using UnityEngine;

public class TideMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private Vector2 velocity;
    private Vector2 maxVelocity;
    private Vector2 acceleration;
    private float stop = 0.0f;
    private bool check = false;


    void Awake()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb2d.bodyType = RigidbodyType2D.Kinematic;

        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, -0.2f);

        maxVelocity = new Vector2(0.0f, 5.0f);
        acceleration = new Vector2(0.0f, 0.002f);
    }

    private void Update()
    {
        if(check == false)
        {
            rb2d.velocity = new Vector2(velocity[0], rb2d.velocity[1] + acceleration[1]);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity[1]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            check = true;
            rb2d.velocity = new Vector2(stop, stop);
        }
    }
}
