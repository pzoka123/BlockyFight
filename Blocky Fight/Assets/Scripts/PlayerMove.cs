using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2D;
    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = rgbd2D.velocity;
    }
	
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
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
        if (Input.GetKeyDown(KeyCode.W) == true && velocity.y == 0)
        {
            rgbd2D.AddForce(new Vector2(0, 500)); 
        }
        else
        {
            velocity.y = rgbd2D.velocity.y;
        }
        rgbd2D.velocity = velocity;
    }
}
