using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("ChristmasMission");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
