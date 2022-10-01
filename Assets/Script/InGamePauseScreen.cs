using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseScreen : MonoBehaviour
{
	public GameObject PauseScreen;

	public void Start()
	{
		HideScreen();
	}

	public void ToggleScreen()
	{
		if (PauseScreen.activeSelf)
			HideScreen();
		else
			ShowScreen();
	}

	private void ShowScreen()
	{
		Time.timeScale = 0;
		PauseScreen.SetActive(true);
	}

	private void HideScreen()
	{
		Time.timeScale = 1;
		PauseScreen.SetActive(false);
	}

	public void ExitToMainMenu()
	{
		GameManager.Instance.BackToMainMenu();
	}

	public void ReloadScene()
	{
		GameManager.Instance.Reload();
	}
}
