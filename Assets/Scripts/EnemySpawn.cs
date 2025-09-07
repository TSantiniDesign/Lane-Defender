using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnTimer;
    [SerializeField] private GameObject snakeEnemy;
    [SerializeField] private GameObject snailEnemy;
    [SerializeField] private int enemyType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = Random.Range(3, 15);
        enemyType = Random.Range(1, 3);
        InvokeRepeating("spawnDecrease", 0, 1);
    }

    void spawnDecrease()
    {
        spawnTimer--;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            if (enemyType == 1)
            {
                Instantiate(snakeEnemy, transform.position, Quaternion.identity);
                enemyType = Random.Range(1, 3);
            }
            else if (enemyType == 2)
            {
                Instantiate(snailEnemy, transform.position, Quaternion.identity);
                enemyType = Random.Range(1, 3);
            }
            spawnTimer = Random.Range(3, 15);
        }
    }
}
