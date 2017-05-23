using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	Rigidbody2D rgBody;
	float speed = 0.15f;
	float jumpforce = 100f;

	public Transform groundCheckPoint;
	public float groundCheckRad;
	public LayerMask groundLayer;
	public bool isGrounded;


	// Use this for initialization
	void Start()
	{
		rgBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRad, groundLayer);

		move();
	}

	void move()
	{
		float moveX = Input.GetAxis("Horizontal");
		rgBody.position += new Vector2 (moveX * speed, 0);

		if (Input.GetKey (KeyCode.W) && isGrounded)
		{
			rgBody.AddForce (new Vector2 (0, jumpforce));
		}
	}
}
