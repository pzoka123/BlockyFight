using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected GameObject[] grounds;

    protected Rigidbody2D rgbd2D;
    public Vector3 velocity;

    protected bool isGrounded;
    public bool isRight;

    // Use this for initialization
    public virtual void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        Load();
        Move();
        Attack();
        Flip();
        if (isGrounded)
        {
            velocity.y = 0;
        }
    }

    protected abstract void Load();

    protected abstract void Move();

    protected abstract void Attack();

    protected void Flip()
    {
        if (velocity.x < 0)
        {
            isRight = false;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (velocity.x > 0)
        {
            isRight = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
