using UnityEngine;

public class SantaMovementAuto : MonoBehaviour
{
    [Header("Movement Settings")] 
    [SerializeField] private float _santaSpeed = 0f;
    [SerializeField] private Rigidbody2D _santaRigidBody;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _santaRigidBody.linearVelocity = transform.right * _santaSpeed;

        if (_santaRigidBody.linearVelocity.sqrMagnitude > 0.1)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
