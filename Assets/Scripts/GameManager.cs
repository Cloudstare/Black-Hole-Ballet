using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float _startTime;
    private float _endTime;
    private bool _gameFinished;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _startTime = Time.time;
        _gameFinished = false;
    }

    private void Update()
    {
        if (!_gameFinished)
        {
            float currentTime = Time.time - _startTime;
            Debug.Log("Current game time: " + currentTime + " seconds");
        }
    }

    public void FinishGame()
    {
        if (!_gameFinished)
        {
            _endTime = Time.time;
            _gameFinished = true;
            SaveGameTime();
        }
    }

    private void SaveGameTime()
    {
        float gameTime = _endTime - _startTime;
        PlayerPrefs.SetFloat("GameTime", gameTime);
        Debug.Log("Game finished! Time: " + gameTime + " seconds");
    }
}