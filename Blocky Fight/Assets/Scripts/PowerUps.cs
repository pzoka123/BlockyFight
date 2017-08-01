using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public GameObject thePlayer;

    void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            thePlayer.GetComponent<Player>().isShielded = true;
            Destroy(gameObject);
        }
    }
}
