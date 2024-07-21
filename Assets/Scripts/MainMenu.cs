using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToSettingsMenu()
    {
        // Load the settings scene
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
