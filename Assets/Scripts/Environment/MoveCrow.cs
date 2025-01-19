using UnityEngine;

public class MoveCrow : MonoBehaviour
{
    [Header("Crow Movement Settings")]
    [SerializeField] private float crowSpeed = 1f;
    
    private void Update()
    {   
        transform.position += Vector3.left * crowSpeed * Time.deltaTime;
    }
}
