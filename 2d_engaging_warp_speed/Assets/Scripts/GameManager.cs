using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gamePaused;
    public GameObject pausePanel;

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        gamePaused = pause;
        pausePanel.SetActive(pause);
    }

    public void QuitPause()
    {
        PauseGame(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame(true);
        }
    }
}
