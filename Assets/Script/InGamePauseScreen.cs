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
		GameManager.Instance.ClickSource.Play();
		if (PauseScreen.activeSelf)
			HideScreen();
		else
			ShowScreen();
	}

	private void ShowScreen()
	{
		GameManager.Instance.ClickSource.Play();
		Time.timeScale = 0;
		PauseScreen.SetActive(true);
	}

	private void HideScreen()
	{
		GameManager.Instance.ClickSource.Play();
		Time.timeScale = 1;
		PauseScreen.SetActive(false);
	}

	public void ExitToMainMenu()
	{
		GameManager.Instance.ClickSource.Play();
		GameManager.Instance.BackToMainMenu();
	}

	public void ReloadScene()
	{
		GameManager.Instance.ClickSource.Play();
		GameManager.Instance.Reload();
		ToggleScreen();
	}
}
