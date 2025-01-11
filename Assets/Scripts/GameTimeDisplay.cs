using UnityEngine;
using TMPro;

public class GameTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI _gameTimeText;

    private void Awake()
    {
        _gameTimeText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.GameFinished)
        {
            float currentTime = Time.time - GameManager.Instance.StartTime;
            int minutes = Mathf.FloorToInt(currentTime / 60F);
            int seconds = Mathf.FloorToInt(currentTime % 60F);
            _gameTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}