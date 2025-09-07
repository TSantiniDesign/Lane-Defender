/*****************************************************************************
// File Name : ExplosionController.cs
// Author : Thomas Santini
// Creation Date : September 4th, 2025 
//
// Brief Description : This script controls the explosions seen in game
when the player shoots and bullets collide with something.
*****************************************************************************/
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    /// <summary>
    /// When the spawn in, they invoke the StopExplode function. The time is supposed to time out for exactly when
    /// the explosion animation ends.
    /// </summary>
    void Start()
    {
        Invoke("StopExplode", .3f);
    }

    /// <summary>
    /// Destroys the explosion.
    /// </summary>
    void StopExplode()
    {
        Destroy(gameObject);
    }
}
