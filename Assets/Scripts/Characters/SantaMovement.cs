using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SantaMovement : MonoBehaviour
{
    [Header("Input Movement")]
    [SerializeField] private InputActionReference _moveInput;
    
    [Header("Movement Stats")]
    [SerializeField] private float _santaSpeed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector2 _realDir;
    
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    
    // Movement Routine 
    private Coroutine MovementCoroutine { get; set; }

    private void Start()
    {
        _moveInput.action.started += StartMovement;
        _moveInput.action.canceled += StopMovement;
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= StartMovement;
        _moveInput.action.canceled -= StopMovement;
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
                _rigidbody2D.linearVelocity = _realDir * _santaSpeed;
                
                _animator.SetBool("IsMoving", true);
                
                yield return null;
            }
        }
    }

    private void StopMovement(InputAction.CallbackContext obj)
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
        
        _animator.SetBool("IsMoving", false);
        
        StopCoroutine(MovementCoroutine);
        MovementCoroutine = null;
    }
}
