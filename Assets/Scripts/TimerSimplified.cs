using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSimplified : MonoBehaviour
{
   float currentTime;
   public float startingTime = 10f;
   public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0) {
            currentTime = 0;

        }
    }
}
