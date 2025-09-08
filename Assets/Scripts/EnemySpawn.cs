/*****************************************************************************
// File Name : EnemySpawn.cs
// Author : Thomas Santini
// Creation Date : September 4th, 2025 
//
// Brief Description : This script controls the enemy spawning, choosing
which enemies to spawn and when.
*****************************************************************************/
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnTimer;
    [SerializeField] private GameObject snakeEnemy;
    [SerializeField] private GameObject snailEnemy;
    [SerializeField] private GameObject slimeEnemy;
    [SerializeField] private int enemyType;

    /// <summary>
    /// When the game begins, the amount of time until the next spawn is determined, and the enemy type is determined.
    /// The countdown is started.
    /// </summary>
    void Start()
    {
        spawnTimer = Random.Range(3, 15);
        enemyType = Random.Range(1, 4);
        InvokeRepeating("spawnDecrease", 0, 1);
    }

    /// <summary>
    /// When called, this decreases the spawning timer.
    /// </summary>
    void spawnDecrease()
    {
        spawnTimer--;
    }

    /// <summary>
    /// When the spawning timer reaches zero, it determines which enemy to spawn, randomizes which enemy will spawn
    /// next, and randomizes how long it will be until the next spawn.
    /// </summary>
    void Update()
    {
        if (spawnTimer <= 0)
        {
            if (enemyType == 1)
            {
                Instantiate(snakeEnemy, transform.position, Quaternion.identity);
                enemyType = Random.Range(1, 4);
            }
            else if (enemyType == 2)
            {
                Instantiate(snailEnemy, transform.position, Quaternion.identity);
                enemyType = Random.Range(1, 4);
            }
            else if (enemyType == 3)
            {
                Instantiate(slimeEnemy, transform.position, Quaternion.identity);
                enemyType = Random.Range(1, 4);
            }

                spawnTimer = Random.Range(3, 15);
        }
    }
}
