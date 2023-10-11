using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public InputAction pauseMenu;
    public GameObject mainMenuObject;


    //These are all different functions that are called when you press on different buttons
    private void OnEnable()
    {
        pauseMenu.performed += ctx => Pause();
        pauseMenu.Enable();
    }
    public void PlayGame(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }
    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
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
}
