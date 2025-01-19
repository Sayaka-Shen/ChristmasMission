using System;
using UnityEngine;

public class CrowCollision : MonoBehaviour
{
    [Header("CrowCollision Settings")] 
    [SerializeField] private GameObject parentObject;
    private const string CollisionLayer = "Player"; 
    
    [Header("SantaLife Settings")]
    private SantaLife _santaLife;
    private SantaPary _santaPary;
    private const float LifeRemoved = 10;

    private void Start()
    {
        _santaPary = FindFirstObjectByType<SantaPary>();
        _santaLife = FindFirstObjectByType<SantaLife>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(CollisionLayer))
        {
            if (!_santaPary.IsParrying)
            {
                _santaLife.RemoveLife(LifeRemoved);   
            }
            
            Destroy(parentObject);
        }
    }
}
