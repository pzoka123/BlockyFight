using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float test;
    public GameObject target;
    GameObject[] enemies;

    //bool canJump;

    // Use this for initialization
    public override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;
    }

    protected override void Load()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), enemies[i].GetComponent<BoxCollider2D>());
        }
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

        if (target.activeSelf == true)
        {
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

            // Jumping AI
            /*
            if (CheckTargetPos() == true && canJump == true && isGrounded == true)
            {
                velocity.y = 8;
            }
            else
            {
                velocity.y = rgbd2D.velocity.y;
            }
            */
        }
        else
        {
            velocity.x = 0;
            //velocity.y = rgbd2D.velocity.y;
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

        /*
        if (coll.gameObject.tag == "Jump Spot")
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        */
    }

    /*
    bool CheckTargetPos()
    {
        if (target.transform.position.y > gameObject.transform.position.y)
        {
            return true;
        }
        return false;
    }
    */
}
