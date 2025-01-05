using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SantaMovement : MonoBehaviour
{
    [Header("Input Movement")]
    [SerializeField] private InputActionReference moveInput;
    
    [Header("Movement Stats")]
    [SerializeField] private float santaSpeed = 5f;
    [SerializeField] private Rigidbody2D rb2D;
    private Vector2 _realDir;
    
    [Header("Animation")]
    [SerializeField] private Animator animator;
    
    // Movement Routine 
    private Coroutine MovementCoroutine { get; set; }

    private void Start()
    {
        moveInput.action.started += StartMovement;
        moveInput.action.canceled += StopMovement;
    }

    private void OnDestroy()
    {
        moveInput.action.started -= StartMovement;
        moveInput.action.canceled -= StopMovement;
    }

    private void StartMovement(InputAction.CallbackContext obj)
    {
        MovementCoroutine = StartCoroutine(Move());
        IEnumerator Move()
        {
            while (true)
            {
                Vector2 direction = obj.ReadValue<Vector2>();
                _realDir = new Vector2(direction.x, direction.y);
                rb2D.linearVelocity = _realDir * santaSpeed;
                
                animator.SetBool("IsMoving", true);
                
                yield return null;
            }
        }
    }

    private void StopMovement(InputAction.CallbackContext obj)
    {
        rb2D.linearVelocity = Vector2.zero;
        
        animator.SetBool("IsMoving", false);
        
        StopCoroutine(MovementCoroutine);
        MovementCoroutine = null;
    }
}
