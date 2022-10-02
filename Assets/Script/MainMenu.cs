using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public string GameSceneName;
	public GameObject Credits;
	public AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	public void StartGame()
	{
		source.Play();
		SceneManager.LoadScene(GameSceneName);
	}

	public void ToggleCredits()
	{
		source.Play();
		Credits.SetActive(!Credits.activeSelf);
	}

	public void ExitGame()
	{
		source.Play();
		Application.Quit(0);
	}
}
