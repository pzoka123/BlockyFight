using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject bullet;

    public bool isShielded;

    // Use this for initialization
    public override void Start()
    {
        isRight = true;
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;
    }

    protected override void Load()
    {
        if (isShielded == true)
        {
            gameObject.transform.Find("Canvas").gameObject.SetActive(true);
        }
        else if (isShielded == false)
        {
            gameObject.transform.Find("Canvas").gameObject.SetActive(false);
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
        if (Input.GetKey(KeyCode.W) == true && isGrounded == true)
        {
            velocity.y = 8;
        }
        else
        {
            velocity.y = rgbd2D.velocity.y;
        }
        rgbd2D.velocity = velocity;
    }

    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRight)
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(1, 0, 0), gameObject.transform.rotation);
            }
            else if (isRight == false)
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(-1, 0, 0), gameObject.transform.rotation);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (isShielded == true)
            {
                isShielded = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
