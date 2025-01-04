using UnityEngine;

public class SantaMovementAuto : MonoBehaviour
{
    [Header("Movement Settings")] 
    [SerializeField] private float _santaSpeed = 3f;
    [SerializeField] private Rigidbody2D _santaRigidBody;
    [SerializeField] private Animator _animator;
    
    [Header("Difficulty Settings")]
    [SerializeField] private GameTimer _gameTimer;
    private bool _hasFirstSpeedIncreased = false;
    private bool _hasSecondSpeedIncreased = false;
    private bool _gameEnd = false;
    
    private void Update()
    {
        _santaSpeed = ManageSantaSpeedDifficulty();
        
        _santaRigidBody.linearVelocity = transform.right * _santaSpeed;
        
        SetSantaAnimation();
    }

    private void SetSantaAnimation()
    {
        if (_santaRigidBody.linearVelocity.sqrMagnitude > 0.1)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private float ManageSantaSpeedDifficulty()
    {
        if (_gameTimer.TimeRemaining <= _gameTimer.FirstSpeedUp && !_hasFirstSpeedIncreased)
        {
            Debug.Log("La vitesse de Santa augmente !");
            _santaSpeed *= 2;
            _hasFirstSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= _gameTimer.SecondSpeedUp && !_hasSecondSpeedIncreased)
        {
            Debug.Log("La vitesse de Santa augmente encore !");
            _santaSpeed += 2;
            _hasSecondSpeedIncreased = true;
        }
    
        if (_gameTimer.TimeRemaining <= 0 && !_gameEnd)
        {
            _gameEnd = true;
        }
    
        return _santaSpeed;
    }
}
