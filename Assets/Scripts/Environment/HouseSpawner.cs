using System;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject parentHouse;
    [SerializeField] private float maxTime;
    [SerializeField] private Camera cameraObject;
    private float _timer;
    
    [Header("Chimney Collision Settings")]
    [SerializeField] private PointSystem pointSystem;

    private void Start()
    {
        SpawnHouse();
    }

    private void Update()
    {
        if (_timer > maxTime)
        {
            SpawnHouse();
            _timer = 0;
        }
        
        _timer += Time.deltaTime;
        
        Vector3 cameraPosition = cameraObject.transform.position;
        transform.position = new Vector3(cameraPosition.x + 12, transform.position.y, transform.position.z);
    }

    private void SpawnHouse()
    {
        Vector3 spawnPos = transform.position;
        
        GameObject house = Instantiate(housePrefab, spawnPos, Quaternion.identity);
        house.transform.SetParent(parentHouse.transform);
        
        // Get the chimneyCollision component from house
        ChimneyCollision chimneyCollision = house.transform.GetChild(1).GetChild(1).GetComponent<ChimneyCollision>();

        if (chimneyCollision != null)
        {
            chimneyCollision.OnChimneyCollision += pointSystem.AddPoints;
        }
        
        Destroy(house, 10f);
    }
}
