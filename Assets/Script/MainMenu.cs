using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public string GameSceneName;
	public GameObject Credits;

	public void StartGame()
	{
		SceneManager.LoadScene(GameSceneName);
	}

	public void ToggleCredits()
	{
		Credits.SetActive(!Credits.activeSelf);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
