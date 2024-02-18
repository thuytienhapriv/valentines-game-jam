using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerBar;
    private float timeRemaining;
    public float maxTime = 45.0f;

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
            timerBar.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            Debug.Log(" time run out ");
                         
        }
    }
}
