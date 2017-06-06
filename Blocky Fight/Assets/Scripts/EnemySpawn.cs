using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn",0f, 5f);
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject Spawn()
    {
        GameObject newEnemy;
        newEnemy = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        return newEnemy;
    }
}
