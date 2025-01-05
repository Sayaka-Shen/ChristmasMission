using UnityEngine;
using UnityEngine.InputSystem;

public class HandlePauseMenu : MonoBehaviour
{
    [Header("Menu Settings")]
    [SerializeField] private InputActionReference pauseMenuInput;
    [SerializeField] private GameObject pauseMenu;
    
    private void Start() {
        pauseMenuInput.action.performed += StartPauseMenu;
    }

    private void OnDestroy()
    {
        pauseMenuInput.action.performed -= StartPauseMenu;
    }
    
    private void StartPauseMenu(InputAction.CallbackContext context)
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);   
            Time.timeScale = 0f;
        }
    }
    
    // Button Event
    public void CloseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
