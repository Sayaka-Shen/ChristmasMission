using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    [Header("CrowSpawner Settings")]
    [SerializeField] private GameObject crowPrefab;
    [SerializeField] private GameObject crowParent;
    [SerializeField] private float maxTime;
    [SerializeField] private Camera cameraObject;
    private float _timer;
    private int _randomSpaceWithCamera;
    
    private void Start()
    {
        SpawnCrow();
    }

    private void Update()
    {
        if (_timer > maxTime)
        {
            SpawnCrow();    
            _timer = 0;
        }
        
        _timer += Time.deltaTime;
        
        _randomSpaceWithCamera = Random.Range(8, 20);
        Vector3 cameraPos = cameraObject.transform.position;
        transform.position = new Vector3(cameraPos.x + _randomSpaceWithCamera, transform.position.y, transform.position.z);
    }

    private void SpawnCrow()
    {
        Vector3 spawnPos = transform.position;
        
        GameObject crow = Instantiate(crowPrefab, spawnPos, Quaternion.identity);
        crow.transform.SetParent(crowParent.transform);
        
        Destroy(crow, 10f);
    }
}
