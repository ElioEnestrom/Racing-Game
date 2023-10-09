using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public InputAction pauseMenu;
    public GameObject mainMenuObject;

    public void Awake()
    {

    }
    private void OnEnable()
    {
        pauseMenu.performed += ctx => Pause();
        pauseMenu.Enable();
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        mainMenuObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PlaySettings()
    {

    }
}
