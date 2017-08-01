using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour {

    public GameObject powerUp;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnPower",5f, 10f);
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    GameObject SpawnPower()
    {
        if (player.activeSelf == true)
        {
            GameObject newPowerUp;
            newPowerUp = Instantiate(powerUp, GetSpawnPos(), gameObject.transform.rotation) as GameObject;
            return newPowerUp;
        }
        else
        {
            return null;
        }
    }

    Vector3 GetSpawnPos()
    {
        float rndX = Random.Range(-21.0f, 21.0f);
        float rndY = Random.Range(-8.5f, 2.0f);
        Vector3 spawnPos = new Vector3(rndX, rndY, 0);
        Collider2D overlap = Physics2D.OverlapCircle(spawnPos, 1.5f);
        if (overlap != null)
        {
            return GetSpawnPos();
        }
        else
        {
            return spawnPos;
        }
    }
}
