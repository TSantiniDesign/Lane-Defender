using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerinput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerinput.currentActionMap.Enable();
    }

    void OnRestart()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
