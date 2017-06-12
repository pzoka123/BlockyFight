using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn",8f, 8f);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject Spawn()
    {
        if (player.activeSelf == true)
        {
            GameObject newEnemy;
            newEnemy = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            return newEnemy;
        }
        else
        {
            return null;
        }
    }
}
