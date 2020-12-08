using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
