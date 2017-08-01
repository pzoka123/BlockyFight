using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    [SerializeField]
    private Stat health;

    void Awake()
    {
        health.Initialize();
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health.CurVal == 0)
        {
            gameObject.SetActive(false);
        }
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            health.CurVal -= 0.5f;
        }
    }
}
