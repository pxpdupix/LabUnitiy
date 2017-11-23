using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager SharedInstance;
	public bool gamePaused;
	private bool _gameover=false;
	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public GameObject gameWinPanel;
	public Health _health;
	void Awake () {
		SharedInstance = this;
	}
	void Start () {
		Time.timeScale = 1;
	}
	public void PauseGame(bool pause)
	{
		Time.timeScale = pause ? 0 : 1;
		gamePaused = pause;
		pausePanel.SetActive(pause);
	}
	public void GameOver(bool gmovr){
		Time.timeScale = gmovr ? 0 : 1;
		gameOverPanel.SetActive(gmovr);
	}
	public void GameWin(bool gmwn){
		Time.timeScale = gmwn ? 0 : 1;
		gameWinPanel.SetActive(gmwn);
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
		if (_health.currentHealth <= 0) {
			GameOver (true);
		}
	}
}