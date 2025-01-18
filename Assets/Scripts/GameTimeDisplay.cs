using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI _gameTimeText;

    private void Awake()
    {
        _gameTimeText = GetComponent<TextMeshProUGUI>();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the start time when a new scene is loaded
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
