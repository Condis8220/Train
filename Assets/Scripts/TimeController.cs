using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text view;

    public int timeInSeconds = 300;
    private float timer;
    private float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;

            if (timer < 0)
                timer = 0;

            UpdateViewTimer();
        }
    }

    private void Start()
    {
        Timer = timeInSeconds;
    }

    private void Update()
    {
        if (!WinController.Instance.IsGame)
            return;

        Timer -= Time.deltaTime;

        if (Timer == 0)
            WinController.Instance.ShowScreen();
    }

    private void UpdateViewTimer()
    {
        int min = (int)Timer / 60;
        int sec = (int)Timer % 60; 
        view.text = $"Время: {min}:{(sec < 10 ? "0" + sec : sec.ToString())}";
    }
}
