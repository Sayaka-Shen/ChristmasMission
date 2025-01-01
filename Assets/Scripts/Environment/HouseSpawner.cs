using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class HouseSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject _housePrefab;
    [SerializeField] private float _maxTime;
    [SerializeField] private Camera _camera;
    private float _timer;

    private void Start()
    {
        SpawnHouse();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnHouse();
            _timer = 0;
        }
        
        _timer += Time.deltaTime;
        
        Vector3 cameraPosition = _camera.transform.position;
        transform.position = new Vector3(cameraPosition.x + 12, transform.position.y, transform.position.z);
    }

    private void SpawnHouse()
    {
        Vector3 spawnPos = transform.position;
        
        GameObject house = Instantiate(_housePrefab, spawnPos, Quaternion.identity);
            
        Destroy(house, 10f);
    }
}
