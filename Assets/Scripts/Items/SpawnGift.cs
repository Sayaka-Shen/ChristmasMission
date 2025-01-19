using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnGift : MonoBehaviour
{
    [Header("Prefab References")]
    [SerializeField] private GameObject giftPrefab;
    private GameObject _giftInstance;
    
    [Header("Spawn Gift Settings")]
    [SerializeField] private GameObject spawnZone;
    [SerializeField] private GameObject giftParent;
    private bool _canSpawnGift = true;
    
    [Header("Throw Input")]
    [SerializeField] private InputActionReference throwInput;

    private void Start()
    {
        throwInput.action.started += StartThrow;
    }

    private void OnDestroy()
    {
        throwInput.action.started -= StartThrow;
    }

    private void StartThrow(InputAction.CallbackContext context)
    {
        if (_canSpawnGift)
        {
            _giftInstance = Instantiate(giftPrefab, spawnZone.transform);
            _giftInstance.transform.SetParent(giftParent.transform);    
            _canSpawnGift = false;
            
            SoundManager.Instance.PlaySound3D("GiftDrop", transform.position);
            
            StartCoroutine( WaitBeforeSpawningNewGift());
        }
    }

    IEnumerator WaitBeforeSpawningNewGift()
    {
        yield return new WaitForSeconds(1.5f);

        _canSpawnGift = true;
    }
}
