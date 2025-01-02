using System;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    // Point Settings
    private int _totalPoints = 0;

    public void AddPoints(int pointsAdded)
    {
        _totalPoints += pointsAdded;
        Debug.Log(_totalPoints);
    }
}
