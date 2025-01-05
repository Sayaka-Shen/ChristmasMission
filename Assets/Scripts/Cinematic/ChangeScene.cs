using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeScene : MonoBehaviour
{
    [Header("Change Scene Settings")] 
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private InputActionReference skipInput;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;

        skipInput.action.started += StartSkipCinematic;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void StartSkipCinematic(InputAction.CallbackContext context)
    {
        videoPlayer.Stop();
        videoPlayer.time = 0;
        SceneManager.LoadScene("StartMenu");
    }
}
