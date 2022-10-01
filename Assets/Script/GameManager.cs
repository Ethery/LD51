using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int currentLevel = 1;
	public int lastLevel = 3;

	public GameObject WinScreen;
	public GameObject LoseScreen;

	public static GameManager Instance;

	public Clock clock;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);

	}

	private void Start()
	{
		SceneManager.LoadScene("Level_" + currentLevel, LoadSceneMode.Additive);
	}

	public void WinLevel()
	{
		if (lastLevel != currentLevel)
		{
			SceneManager.UnloadSceneAsync("Level_" + (currentLevel++));
			SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
			clock.Reset();
		}
		else
		{
			WinScreen.SetActive(true);
		}
	}

	public void Reload()
	{
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel));
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		clock.Reset();
	}
	public void GoToLevel(int aLevelToGo)
	{
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel));
		currentLevel = aLevelToGo;
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		clock.Reset();
	}
	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	internal void Lose()
	{
		LoseScreen.SetActive(true);
	}
}
