using System;
using UnityEngine;

public class ChimneyCollision : MonoBehaviour
{
    // Event for the gift colliding with chimney
    public event Action<int> OnChimneyCollision;
    
    // Const for points system addition of point
    private const int PointAdded = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnChimneyCollision?.Invoke(PointAdded);
    }
}
