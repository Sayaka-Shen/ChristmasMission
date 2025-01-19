using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SantaPary : MonoBehaviour
{
    [Header("SantaPary Settings")]
    [SerializeField] private InputActionReference defenseInput;
    [SerializeField] private GameObject paryFeedback;

    public bool IsParrying { get; private set; }

    private void Start()
    {
        defenseInput.action.started += Pary;
    }

    private void OnDestroy()
    {
        defenseInput.action.started -= Pary;
    }

    private void Pary(InputAction.CallbackContext context)
    {
        if(IsParrying) { return; }
        
        IsParrying = true;
        paryFeedback.SetActive(true);

        StartCoroutine(WaitBeforeStopParrying());
    }

    IEnumerator WaitBeforeStopParrying()
    {
        yield return new WaitForSeconds(0.5f);
        
        IsParrying = false;
        paryFeedback.SetActive(false);
    }
}
