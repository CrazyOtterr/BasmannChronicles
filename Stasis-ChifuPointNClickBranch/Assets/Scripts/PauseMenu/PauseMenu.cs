using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public static bool Is_in_pause = false;

    void Awake()
    {
        Is_in_pause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseGameMenu.SetActive(false);
        // collectablesGameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        PauseGame = false;
        Is_in_pause = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseGameMenu.SetActive(true);
        // collectablesGameMenu.SetActive(false);
        Time.timeScale = 0f;
        PauseGame = true;
        Is_in_pause = true;
    }

    public void Menu()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseGameMenu.SetActive(false);
        // collectablesGameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        PauseGame = false;
        Is_in_pause = false;
    }
}
