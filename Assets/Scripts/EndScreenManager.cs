using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TarodevController; // Adjust as necessary

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScreenText;
    [SerializeField] private GameObject clearScoresButton;
    [SerializeField] private GameObject playAgainButton;

    private void Start()
    {
        gameObject.SetActive(false); // Hide the end screen initially
    }

    public void ShowEndScreen(float gameTime)
    {
        gameObject.SetActive(true);

        // Format the time for display
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        int seconds = Mathf.FloorToInt(gameTime % 60F);

        // Display a congratulatory message with the time
        endScreenText.text = $"Congratulations!";

        // Disable player movement
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void ClearScores()
    {
        PlayerPrefs.DeleteKey("GameTimesCount");
        for (int i = 0; i < 100; i++) // Assuming a maximum of 100 scores
        {
            PlayerPrefs.DeleteKey("GameTime" + i);
        }
        endScreenText.text = "Scores Cleared!";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
