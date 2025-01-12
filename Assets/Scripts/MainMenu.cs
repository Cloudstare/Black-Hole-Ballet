using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public static void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}