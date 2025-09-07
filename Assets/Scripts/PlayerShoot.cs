/*****************************************************************************
// File Name : PlayerShoot.cs
// Author : Thomas Santini
// Creation Date : September 3rd, 2025 
//
// Brief Description : This script controls the player's shooting, giving
them slight delays between firing if the button is held down.
*****************************************************************************/
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameObject explosion;

    private InputAction shoot;

    /// <summary>
    /// The input action map and shooting actions are enabled on startup.
    /// </summary>
    void Start()
    {
        playerInput.currentActionMap.Enable();

        shoot = playerInput.currentActionMap.FindAction("Shoot");

        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
    }

    /// <summary>
    /// Invokes the SpawnBullet function with a short delay in between each shot.
    /// </summary>
    private void Shoot_started(InputAction.CallbackContext context)
    {
        InvokeRepeating("SpawnBullet", 0, .4f);
    }

    /// <summary>
    /// Stop the invoke when the shoot button is no longer being held down.
    /// </summary>
    private void Shoot_canceled(InputAction.CallbackContext context)
    {
        CancelInvoke();
    }

    /// <summary>
    /// Spawns the bullet and explosion animation to hide the spawn of the bullet, and plays the shoot noise.
    /// </summary>
    void SpawnBullet()
    {
        Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
        Instantiate(explosion, bulletSpawn.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 1f);
    }
}
