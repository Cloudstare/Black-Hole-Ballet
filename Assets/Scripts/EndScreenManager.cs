using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScreenText;

    private void Start()
    {
        gameObject.SetActive(false); // Ukryj ekran końcowy na początku
    }

    public void ShowEndScreen(float gameTime)
    {
        gameObject.SetActive(true);
        List<float> gameTimes = GameManager.Instance.GetGameTimes();
        string timesText = "Game Over\nTimes:\n";
        foreach (float time in gameTimes)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            timesText += string.Format("{0:00}:{1:00}\n", minutes, seconds);
        }
        endScreenText.text = timesText;
    }
}