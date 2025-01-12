using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;


public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;

    private void Start()
    {
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        List<float> gameTimes = GameManager.Instance.GetGameTimes();

        if (gameTimes == null || gameTimes.Count == 0)
        {
            leaderboardText.text = "No scores yet! Play to set your best times.";
            return;
        }

        List<(float time, string name)> scores = gameTimes
            .Select(time => (time, "Player"))
            .OrderBy(score => score.time)
            .Take(7)
            .ToList();

        string timesText = "";
        int place = 1;
        foreach (var score in scores)
        {
            int minutes = Mathf.FloorToInt(score.time / 60F);
            int seconds = Mathf.FloorToInt(score.time % 60F);
            timesText += $"{place}. {score.name} - {minutes:00}:{seconds:00}\n";
            place++;
        }

        leaderboardText.text = timesText;
    }
    public void ClearScores()
    {
        PlayerPrefs.DeleteKey("GameTimesCount");
        for (int i = 0; i < 100; i++) // Assuming a maximum of 100 scores
        {
            PlayerPrefs.DeleteKey("GameTime" + i);
        }
        DisplayLeaderboard();
    }
}
