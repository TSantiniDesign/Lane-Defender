using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = Random.Range(3, 7);
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
            print("enemy spawned");
            spawnTimer = Random.Range(3, 7);
        }
    }
}
