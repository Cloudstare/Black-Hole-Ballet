using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private EndScreenManager endScreenManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.FinishGame();
            float gameTime = PlayerPrefs.GetFloat("GameTime");
            endScreenManager.ShowEndScreen(gameTime);
        }
    }
}