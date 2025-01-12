using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float _startTime;
    private float _endTime;
    private bool _gameFinished;

    public float StartTime => _startTime;
    public bool GameFinished => _gameFinished;

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
        List<float> gameTimes = GetGameTimes();
        gameTimes.Add(gameTime);
        SaveGameTimes(gameTimes);
        Debug.Log("Game finished! Time: " + gameTime + " seconds");
    }

    public List<float> GetGameTimes()
    {
        List<float> gameTimes = new List<float>();
        int count = PlayerPrefs.GetInt("GameTimesCount", 0);
        for (int i = 0; i < count; i++)
        {
            gameTimes.Add(PlayerPrefs.GetFloat("GameTime" + i));
        }
        return gameTimes;
    }

    private void SaveGameTimes(List<float> gameTimes)
    {
        PlayerPrefs.SetInt("GameTimesCount", gameTimes.Count);
        for (int i = 0; i < gameTimes.Count; i++)
        {
            PlayerPrefs.SetFloat("GameTime" + i, gameTimes[i]);
        }
    }

    public void ResetGame()
    {
        _startTime = Time.time;
        _gameFinished = false;
    }
}