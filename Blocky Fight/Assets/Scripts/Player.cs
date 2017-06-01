using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Use this for initialization
    public override void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;
    }

    protected override void Move()
    {
        for (int i = 0; i < grounds.Length; i++)
        {
            if (gameObject.GetComponent<EdgeCollider2D>().IsTouching(grounds[i].GetComponent<BoxCollider2D>()))
            {
                isGrounded = true;
                break;
            }
            else
            {
                isGrounded = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 5;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -5;
        }
        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            velocity.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.W) == true && isGrounded == true)
        {
            rgbd2D.AddForce(new Vector2(0, 500)); 
        }
        else
        {
            velocity.y = rgbd2D.velocity.y;
        }
        rgbd2D.velocity = velocity;
    }

    protected override void Flip()
    {
        if (velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
