using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using TarodevController; // Dodaj odpowiednią przestrzeń nazw

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScreenText;
    [SerializeField] private GameObject clearScoresButton;
    [SerializeField] private GameObject playAgainButton;

    private void Start()
    {
        gameObject.SetActive(false); // Ukryj ekran końcowy na początku
    }

    public void ShowEndScreen(float gameTime)
    {
        gameObject.SetActive(true);

        // Get game times
        List<float> gameTimes = GameManager.Instance.GetGameTimes();

        // Create a list of pairs (time, player name)
        List<(float time, string name)> scores = new List<(float, string)>();
        for (int i = 0; i < gameTimes.Count; i++)
        {
            scores.Add((gameTimes[i], "Player"));
        }

        // Sort and take top 7 scores
        scores = scores.OrderBy(score => score.time).Take(7).ToList();

        // Prepare the final text
        string timesText = "Congratulations!\nTop Scores:\n\n";
        int place = 1;
        foreach (var score in scores)
        {
            int minutes = Mathf.FloorToInt(score.time / 60F);
            int seconds = Mathf.FloorToInt(score.time % 60F);
            timesText += string.Format("{0}. {1} - {2:00}:{3:00}\n", place, score.name, minutes, seconds);
            place++;
        }

        // Display the results on the end screen
        endScreenText.text = timesText;

        // Disable player movement and make player disappear
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.SetActive(false); // Make player disappear
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
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}