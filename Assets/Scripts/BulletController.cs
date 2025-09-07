/*****************************************************************************
// File Name : BulletController.cs
// Author : Thomas Santini
// Creation Date : September 3rd, 2025 
//
// Brief Description : This script controls the bullets shot by the player.
They move continuously to the right, and create an explosion and disappear
when the collide with anything.
*****************************************************************************/
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    /// <summary>
    /// Once spawned, they continously move to the right.
    /// </summary>
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(20, 0);
    }

    /// <summary>
    /// When the collide with something, they create an explosion animation, and destroy themselves.
    /// </summary>
    /// <param name="collision">The object they collide with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
