using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float test;
    public GameObject target;
    GameObject[] enemies;

    bool moveLeft;

    bool isAtGoal;

    int health;

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

        health = 100;
    }

    protected override void Load()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), enemies[i].GetComponent<BoxCollider2D>());
        }

        if (health == 0)
        {
            Destroy(gameObject);
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
        if (coll.gameObject.tag == "Player BulletDefault")
        {
            health -= 50;
            rgbd2D.AddForce(new Vector2(10000f, 250f));
        }
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
}
