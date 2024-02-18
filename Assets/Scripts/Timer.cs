using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Image timerBar;
    public float timeRemaining;
    public float maxTime = 45.0f;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log(timeRemaining);
            timerBar.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            Debug.Log(" time run out ");
                         
        }

        if (timeRemaining <= 0)
        {
            GameManager.instance.Lose();
        }
    }
}
