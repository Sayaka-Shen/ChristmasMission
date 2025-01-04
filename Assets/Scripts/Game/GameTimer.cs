using System;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")] 
    [SerializeField] private float _timeRemaining;
    private bool _isTimeRunning = false;
    
    [Header("Difficulty Settings")]
    private float _firstSpeedUp = 120;
    private float _secondSpeedUp = 60;

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
        get { return _timeRemaining; }
    }
    
    private void Start()
    {
        _isTimeRunning = true;
    }

    private void Update()
    {
        if (_isTimeRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out !");
                _timeRemaining = 0;
                _isTimeRunning = false;
            }
        }
        
        
        Debug.Log(ConvertToClassicTime(_timeRemaining));
    }

    private string ConvertToClassicTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string classicTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        return classicTime;
    }
}