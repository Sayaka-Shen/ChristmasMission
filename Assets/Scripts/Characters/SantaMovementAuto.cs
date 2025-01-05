using UnityEngine;
using UnityEngine.InputSystem;

public class SantaMovementAuto : MonoBehaviour
{
    [Header("Movement Settings")] 
    [SerializeField] private float santaSpeed = 3f;
    [SerializeField] private Rigidbody2D santaRigidbody;
    [SerializeField] private Animator animator;
    
    [Header("Difficulty Settings")]
    [SerializeField] private GameTimer gameTimer;
    private bool _hasFirstSpeedIncreased = false;
    private bool _hasSecondSpeedIncreased = false;
    private bool _gameEnd = false;
    
    private void Update()
    {
        santaSpeed = ManageSantaSpeedDifficulty();
        
        santaRigidbody.linearVelocity = transform.right * santaSpeed;
        
        SetSantaAnimation();
    }

    private void SetSantaAnimation()
    {
        if (santaRigidbody.linearVelocity.sqrMagnitude > 0.1)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private float ManageSantaSpeedDifficulty()
    {
        if (gameTimer.TimeRemaining <= gameTimer.FirstSpeedUp && !_hasFirstSpeedIncreased)
        {
            santaSpeed *= 2;
            _hasFirstSpeedIncreased = true;
        }
    
        if (gameTimer.TimeRemaining <= gameTimer.SecondSpeedUp && !_hasSecondSpeedIncreased)
        {
            santaSpeed += 2;
            _hasSecondSpeedIncreased = true;
        }
    
        if (gameTimer.TimeRemaining <= 0 && !_gameEnd)
        {
            santaSpeed = 0;
            _gameEnd = true;
        }
    
        return santaSpeed;
    }
}
