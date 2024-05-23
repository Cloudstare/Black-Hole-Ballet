using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Dodaj tę linię

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    public TMP_Text timerText;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1");
    }
}
