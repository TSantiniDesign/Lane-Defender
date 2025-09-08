using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private GameObject music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerinput.currentActionMap.Enable();
    }

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

    void OnRestart()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
