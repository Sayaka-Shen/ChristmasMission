using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("GameMusic");
    }
}
