using TMPro;  // Required for TextMeshPro
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;  // Drag your TextMeshPro object here

    private void Start()
    {
        DisplayLeaderboard();
    }

    private void DisplayLeaderboard()
    {
        // Get game times from GameManager
        List<float> gameTimes = GameManager.Instance.GetGameTimes();

        // Create list of scores (time, player name)
        List<(float time, string name)> scores = new List<(float, string)>();
        for (int i = 0; i < gameTimes.Count; i++)
        {
            scores.Add((gameTimes[i], "Player"));
        }

        // Sort scores and take the top 7
        scores = scores.OrderBy(score => score.time).Take(7).ToList();

        // Prepare leaderboard text
        string timesText = "Congratulations!\nTop Scores:\n\n";
        int place = 1;
        foreach (var score in scores)
        {
            int minutes = Mathf.FloorToInt(score.time / 60F);
            int seconds = Mathf.FloorToInt(score.time % 60F);
            timesText += $"{place}. {score.name} - {minutes:00}:{seconds:00}\n";
            place++;
        }

        // Display on screen
        leaderboardText.text = timesText;
    }
}
