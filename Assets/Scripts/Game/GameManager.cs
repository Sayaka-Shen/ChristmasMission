using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        MusicManager.Instance.PlayMusic("GameMusic");
    }
}
