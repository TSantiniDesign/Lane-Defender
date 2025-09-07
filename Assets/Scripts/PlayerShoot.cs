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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput.currentActionMap.Enable();

        shoot = playerInput.currentActionMap.FindAction("Shoot");

        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
    }

    private void Shoot_started(InputAction.CallbackContext context)
    {
        InvokeRepeating("SpawnBullet", 0, .4f);
    }

    private void Shoot_canceled(InputAction.CallbackContext context)
    {
        CancelInvoke();
    }

    void SpawnBullet()
    {
        Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
        Instantiate(explosion, bulletSpawn.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 1f);
    }
}
