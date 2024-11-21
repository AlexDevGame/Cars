using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Text timerText, recordText;
    private float timer = 0f, record;
    private bool timerRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.HasKey("record"))
        {
            record = PlayerPrefs.GetFloat("record");
        }
        else
        {
            record = 0f;
        }
        DisplayRecord(record);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
        }
        else
        {
            DisplayTime(timer);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milisecs = Mathf.FloorToInt((timeToDisplay * 1000f) % 1000f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milisecs);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
        if(timer < record || record == 0f)
        {
            record = timer;
            PlayerPrefs.SetFloat("record", record);
        }

        DisplayRecord(record);
    }

    private void DisplayRecord(float _record)
    {
        float minutes = Mathf.FloorToInt(_record / 60);
        float seconds = Mathf.FloorToInt(_record % 60);
        float milisecs = Mathf.FloorToInt((_record * 1000f) % 1000f);

        recordText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milisecs);
    }
}
