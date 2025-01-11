using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.FinishGame();
            float gameTime = PlayerPrefs.GetFloat("GameTime");
            Debug.Log("Final game time: " + gameTime + " seconds");
        }
    }
}