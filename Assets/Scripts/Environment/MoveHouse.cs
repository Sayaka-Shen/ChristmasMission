using System;
using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    [Header("Move Settings")] 
    [SerializeField] private float houseSpeed = 1f;
    
    [Header("Difficulty Settings")]
    private GameTimer _gameTimer;
    private bool _hasFirstSpeedIncreased = false;
    private bool _hasSecondSpeedIncreased = false;
    private bool _gameEnd = false;

    private void Start()
    {
        _gameTimer = FindFirstObjectByType<GameTimer>();
    }
    
    private void Update()
    {
        houseSpeed = ManageHouseSpeedDifficulty();
        
        transform.position += Vector3.left * houseSpeed * Time.deltaTime;
    }

    private float ManageHouseSpeedDifficulty()
    {
        if (_gameTimer.TimeRemaining <= _gameTimer.FirstSpeedUp && !_hasFirstSpeedIncreased)
        {
            houseSpeed *= 2;
            _hasFirstSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= _gameTimer.SecondSpeedUp && !_hasSecondSpeedIncreased)
        {
            houseSpeed += 2;
            _hasSecondSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= 0 && !_gameEnd)
        {
            houseSpeed = 0;
            _gameEnd = true;
        }
    
        return houseSpeed;
    }
}
