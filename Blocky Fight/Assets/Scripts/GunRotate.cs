using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		Rotate();
	}

	void Rotate()
	{
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		float angle = Mathf.Atan2 (mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
