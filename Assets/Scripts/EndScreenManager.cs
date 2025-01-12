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
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}