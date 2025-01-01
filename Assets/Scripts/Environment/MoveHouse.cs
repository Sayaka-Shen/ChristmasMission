using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    [Header("Move Settings")] 
    [SerializeField] private float _houseSpeed = 0.65f;

    private void Update()
    {
        transform.position += Vector3.left * _houseSpeed * Time.deltaTime;
    }
}
