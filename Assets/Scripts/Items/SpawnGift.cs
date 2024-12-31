using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnGift : MonoBehaviour
{
    [Header("Prefab References")]
    [SerializeField] private GameObject _giftPrefab;
    private GameObject _giftInstance;
    
    [Header("Spawn Gift Settings")]
    [SerializeField] private GameObject _spawnZone;
    [SerializeField] private GameObject _giftParent;
    private bool _canSpawnGift = true;
    
    [Header("Throw Input")]
    [SerializeField] private InputActionReference _throwInput;

    private void Start()
    {
        _throwInput.action.started += StartThrow;
    }

    private void OnDestroy()
    {
        _throwInput.action.started -= StartThrow;
    }

    private void StartThrow(InputAction.CallbackContext context)
    {
        if (_canSpawnGift)
        {
            _giftInstance = Instantiate(_giftPrefab, _spawnZone.transform);
            _giftInstance.transform.SetParent(_giftParent.transform);    
            _canSpawnGift = false;
            
            StartCoroutine(DeleteGift());
        }
    }


    IEnumerator DeleteGift()
    {
        yield return new WaitForSeconds(1f);
        
        if (_giftInstance != null) 
        {
            Destroy(_giftInstance);
        }

        _canSpawnGift = true;
    }
}
