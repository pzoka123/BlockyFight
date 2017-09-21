using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float test;
    public GameObject target;
    GameObject[] enemies;

    private bool moveLeft;

    private bool isAtGoal;

    //bool canJump;

    // Use this for initialization
    public override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Goal");
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;

        int rnd = Random.Range(0, 10);
        if (rnd < 5)
        {
            moveLeft = true;
        }
        else if (rnd >= 5)
        {
            moveLeft = false;
        }
    }

    protected override void Load()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), enemies[i].GetComponent<BoxCollider2D>());
        }

        if (isAtGoal == true)
        {
            if (moveLeft == true)
            {
                gameObject.transform.Find("hammer").gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            gameObject.transform.Find("hammer").gameObject.SetActive(true);
        }
        else if (isAtGoal == false)
        {
            gameObject.transform.Find("hammer").gameObject.SetActive(false);
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

        // Seek the goal
        /*
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
            //if (CheckTargetPos() == true && canJump == true && isGrounded == true)
            //{
            //    velocity.y = 8;
            //}
            //else
            //{
            //   velocity.y = rgbd2D.velocity.y;
            //}
        }
        else
        {
            velocity.x = 0;
            //velocity.y = rgbd2D.velocity.y;
        }
        */

        if (moveLeft)
        {
            velocity.x = -2;
        }
        else if (moveLeft == false)
        {
            velocity.x = 2;
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Wall")
        {
            moveLeft = !moveLeft;
        }
        if (coll.gameObject.tag == "Shell")
        {
            isAtGoal = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shell")
        {
            isAtGoal = false;
        }
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
