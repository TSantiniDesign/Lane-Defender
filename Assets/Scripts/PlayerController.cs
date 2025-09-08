/*****************************************************************************
// File Name : PlayerController.cs
// Author : Thomas Santini
// Creation Date : September 3rd, 2025 
//
// Brief Description : This script controls the player's movement, using the
input action map to allow the player to move up and down based on the keys
they press.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private float playerSpeed = 15f;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip shootSound;

    private Rigidbody2D rb;
    private Vector3 playerMovement;

    /// <summary>
    /// When the game starts, this script grabs the rigidbody attached to the player, and enables the current action
    /// map to be used with movement.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerinput.currentActionMap.Enable();
    }

    /// <summary>
    /// Gets the value from the keyboard and updates the movement variable on the y axis, while multiplying by 
    /// playerSpeed to get the ideal movement speed and direction.
    /// </summary>
    /// <param name="iValue">value read in from the keyboard</param>
    void OnMove(InputValue iValue)
    {
        Vector2 inputMovement = iValue.Get<Vector2>();
        playerMovement.y = inputMovement.y * playerSpeed;
    }

    /// <summary>
    /// Moves the player based off their inputs.
    /// </summary>
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, playerMovement.y, playerMovement.z);
    }
}
