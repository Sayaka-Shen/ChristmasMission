using System;
using System.Collections;
using UnityEngine;

public class GiftCollision : MonoBehaviour
{
    [Header("Gift Collision Settings")]
    [SerializeField] private GameObject _giftParent;
    private PointSystem _pointSystem;
    
    private const int PointRemoved = 5;

    private void Start()
    {
        _pointSystem = FindFirstObjectByType<PointSystem>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Chimney"))
        {
            if (_pointSystem.TotalPoints > 0)
            {
                _pointSystem.RemovePoints(PointRemoved);    
            }

            Destroy(_giftParent);
        }
    }
}
