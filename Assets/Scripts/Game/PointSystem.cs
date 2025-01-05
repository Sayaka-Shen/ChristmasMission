using System;
using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [Header("Point Settings")]
    [SerializeField] private TextMeshProUGUI pointText;
    private int _totalPoints = 0;
    
    public int TotalPoints => _totalPoints;

    public void AddPoints(int pointsAdded)
    {
        _totalPoints += pointsAdded;
        pointText.text = _totalPoints.ToString();
    }
}
