using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the next scene in the build index
        PlayerHealth.Instance.AudioMan = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToSettingsMenu()
    {
        // Load the settings scene
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToInstructionMenu()
    {
        SceneManager.LoadScene("InstructionMenu");
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
        PlayerHealth.Instance.ResetPlayer();
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
