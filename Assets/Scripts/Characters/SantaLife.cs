using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SantaLife : MonoBehaviour
{
    [Header("SantaLife Settings")]
    [SerializeField] private float maxLife;
    [SerializeField] private Image lifeFill;
    
    [Header("Menu Santa's Death")]
    [SerializeField] private GameTimer gameTimer;
    
    
    private float CurrentLife { get; set; }

    public bool IsSantaDead => CurrentLife <= 0;
    

    private void Start()
    {
        CurrentLife = maxLife;
        lifeFill.fillAmount = CurrentLife / maxLife; 
    }
    
    private void Update()
    {
        if (IsSantaDead)
        {
            Time.timeScale = 0;
            
            gameTimer.AddEndMenu();
        }
    }

    public void RemoveLife(float amount)
    {
        CurrentLife -= amount;
        lifeFill.fillAmount = CurrentLife / maxLife;
    }
}
