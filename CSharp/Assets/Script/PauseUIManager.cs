using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    public bool onPause, onSaveGame;
    public GameObject pause,SaveGame;

    private void Start()
    {
        onPause = true;
        onSaveGame = false;
    }

    private void Update()
    {
        pause.SetActive(onPause);
        SaveGame.SetActive(onSaveGame);
    }

    public void switchToSavegame()
    {
        print("123");
        onPause = !onPause;
        onSaveGame = !onSaveGame;
    }
}
