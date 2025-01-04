using System;
using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    [Header("Move Settings")] 
    [SerializeField] private float _houseSpeed = 1f;
    
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
        _houseSpeed = ManageHouseSpeedDifficulty();
        
        transform.position += Vector3.left * _houseSpeed * Time.deltaTime;
    }

    private float ManageHouseSpeedDifficulty()
    {
        if (_gameTimer.TimeRemaining <= _gameTimer.FirstSpeedUp && !_hasFirstSpeedIncreased)
        {
            Debug.Log("La vitesse de Santa augmente !");
            _houseSpeed *= 2;
            _hasFirstSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= _gameTimer.SecondSpeedUp && !_hasSecondSpeedIncreased)
        {
            Debug.Log("La vitesse de Santa augmente encore !");
            _houseSpeed += 2;
            _hasSecondSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= 0 && !_gameEnd)
        {
            _gameEnd = true;
        }
    
        return _houseSpeed;
    }
}
