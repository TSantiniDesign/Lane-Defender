/*****************************************************************************
// File Name : EnemyBehaviour.cs
// Author : Thomas Santini
// Creation Date : September 3rd, 2025 
//
// Brief Description : This script controls the enemies, controlling where
they move to and how fast, and what happens when they get hit or die.
*****************************************************************************/
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float savedSpeed;
    [SerializeField] private float health;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip lifeSound;
    [SerializeField] private Animator animator;
    [SerializeField] private LivesPlusScore livesPlusScore;
    [SerializeField] private int rowNumber;

    /// <summary>
    /// Sets the saved speed to whatever the speed was set to initially to use later.
    /// </summary>
    void Start()
    {
        FindRow();
        livesPlusScore = FindFirstObjectByType<LivesPlusScore>();
        savedSpeed = speed;
    }

    /// <summary>
    /// Sets the target of the enemy based off of what row it is in.
    /// </summary>
    void FindRow()
    {
        if (rowNumber == 5)
        {
            target = GameObject.Find("RowFiveEnemyGoal");
        }
        else if (rowNumber == 4)
        {
            target = GameObject.Find("RowFourEnemyGoal");
        }
        else if (rowNumber == 3)
        {
            target = GameObject.Find("RowThreeEnemyGoal");
        }
        else if (rowNumber == 2)
        {
            target = GameObject.Find("RowTwoEnemyGoal");
        }
        else if (rowNumber == 1)
        {
            target = GameObject.Find("RowOneEnemyGoal");
        }
    }

    /// <summary>
    /// If the enemy collides with a bullet, it stops for a second, plays a hit sound, and its health decreases.
    /// If it hits the player or the back wall, the lives decrease, the life down noise plays, and the enemy is
    /// destroyed.
    /// </summary>
    /// <param name="collision">The object the enemy collides with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            speed = 0;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 10f);
            health--;
            Invoke("ReturnSpeed", .2f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            livesPlusScore.DecreaseLives();
            AudioSource.PlayClipAtPoint(lifeSound, transform.position, 1f);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When called, the enemy will return to its previous speed.
    /// </summary>
    void ReturnSpeed()
    {
        speed = savedSpeed;
    }

    /// <summary>
    /// This determines the speed at which the enemy moves. If the health is less than or equal to zero, it adds
    /// score, plays a death noise, and dies.
    /// </summary>
    void FixedUpdate()
    {
        animator.SetFloat("Speed", speed);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed *
                Time.deltaTime);
        if (health <= 0)
        {
            livesPlusScore.AddScore();
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 100f);
            Destroy(gameObject);
        }
    }
}
