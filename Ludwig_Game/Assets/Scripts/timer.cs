using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMP_Text timerText;

    public GameObject timerObject;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        timerObject.SetActive(true);
        TimerOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                timerObject.SetActive(true);
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                timerObject.SetActive(false);
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = seconds.ToString();
    }
}
