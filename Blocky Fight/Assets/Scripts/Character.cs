using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected GameObject[] grounds;

    protected Rigidbody2D rgbd2D;
    public Vector3 velocity;

    protected bool isGrounded;

    // Use this for initialization
    public virtual void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        Attack();
        if (isGrounded)
        {
            velocity.y = 0;
        }
    }

    protected abstract void Move();

    protected abstract void Flip();

    protected abstract void Attack();
}
