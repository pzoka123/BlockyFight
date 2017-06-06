using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    GameObject target;

    // Use this for initialization
    public override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
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

        if (gameObject.transform.position.x < target.transform.position.x)
        {
            velocity.x = 2;
        }
        if (gameObject.transform.position.x > target.transform.position.x)
        {
            velocity.x = -2;
        }
        if (gameObject.transform.position.x == target.transform.position.x)
        {
            velocity.x = 0;
        }
        velocity.y = rgbd2D.velocity.y;
        rgbd2D.velocity = velocity;
    }

    protected override void Attack()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player Bullet")
        {
            Destroy(gameObject);
        }
    }
}
