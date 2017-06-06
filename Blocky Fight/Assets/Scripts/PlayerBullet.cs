using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rgbd2D;

    GameObject player;

    Vector3 velocity;

    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;
        direction = new Vector3(1, 0, 0);

        if (player.GetComponent<Player>().isRight)
        {
            direction.x = 1;
        }
        else if (player.GetComponent<Player>().isRight == false)
        {
            direction.x = -1;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        MoveBullet();
        GameObject.Destroy(gameObject, 2f);
    }

    void MoveBullet()
    {
        velocity.x = 20 * direction.x;
        rgbd2D.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
