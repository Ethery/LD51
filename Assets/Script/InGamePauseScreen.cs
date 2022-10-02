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
		GameManager.Instance.source.Play();
		if (PauseScreen.activeSelf)
			HideScreen();
		else
			ShowScreen();
	}

	private void ShowScreen()
	{
		GameManager.Instance.source.Play();
		Time.timeScale = 0;
		PauseScreen.SetActive(true);
	}

	private void HideScreen()
	{
		GameManager.Instance.source.Play();
		Time.timeScale = 1;
		PauseScreen.SetActive(false);
	}

	public void ExitToMainMenu()
	{
		GameManager.Instance.source.Play();
		GameManager.Instance.BackToMainMenu();
	}

	public void ReloadScene()
	{
		GameManager.Instance.source.Play();
		GameManager.Instance.Reload();
		ToggleScreen();
	}
}
