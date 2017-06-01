using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected GameObject[] grounds;

    protected Rigidbody2D rgbd2D;
    protected Vector3 velocity;

    protected bool isGrounded;
    protected bool isRight;

    // Use this for initialization
    public virtual void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
    }

    protected abstract void Move();

    protected abstract void Flip();
}
