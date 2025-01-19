using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")] 
    [SerializeField] private float timeRemaining;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool _isTimeRunning = false;
    
    [Header("Difficulty Settings")]
    private float _firstSpeedUp = 90;
    private float _secondSpeedUp = 30;
    
    [Header("End Menu Settings")]
    [SerializeField] private GameObject endMenu;
    [SerializeField] private TextMeshProUGUI pointMade;
    [SerializeField] private PointSystem pointSystem;
    

    public float FirstSpeedUp
    {
        get { return _firstSpeedUp; }
    }

    public float SecondSpeedUp
    {
        get { return _secondSpeedUp; }
    }

    public float TimeRemaining
    {
        get { return timeRemaining; }
    }
    
    private void Start()
    {
        _isTimeRunning = true;
    }

    private void Update()
    {
        TimerLoop();
    }

    private void TimerLoop()
    {
        if (_isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = ConvertToClassicTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                _isTimeRunning = false;
                timerText.text = "";
                
                AddEndMenu();
            }
        }
    }

    private string ConvertToClassicTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string classicTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        return classicTime;
    }

    public void AddEndMenu()
    {
        endMenu.SetActive(true);
        Cursor.visible = true;
        pointMade.text = "Points Obtenus: " + pointSystem.TotalPoints.ToString();
        
        StartCoroutine(WaitForThePlayerToSeeResult());
    }

    IEnumerator WaitForThePlayerToSeeResult()
    {
        yield return new WaitForSecondsRealtime(5f);

        SceneManager.LoadScene("StartMenu");
    }
}