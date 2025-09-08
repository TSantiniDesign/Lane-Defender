/*****************************************************************************
// File Name : GameController.cs
// Author : Thomas Santini
// Creation Date : September 6th, 2025 
//
// Brief Description : This script controls the player's ability to restart
the game, toggle the music on and off, and quit.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private GameObject music;

    /// <summary>
    /// When the game starts, the current action map is enabled.
    /// </summary>
    void Start()
    {
        playerinput.currentActionMap.Enable();
    }

    /// <summary>
    /// When the players presses the music toggle button, the music will turn off if it is on, and turn on if
    /// it is off.
    /// </summary>
    void OnMusic()
    {
        if (music.activeInHierarchy == true)
        {
            music.SetActive(false);
        }
        else
        {
            music.SetActive(true);
        }
    }

    /// <summary>
    /// When the player presses the key to restart, it reloads the main scene.
    /// </summary>
    void OnRestart()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    /// <summary>
    /// When the player presses the key to quit, it quits the application.
    /// </summary>
    void OnQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
