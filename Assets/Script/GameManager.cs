using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int currentLevel = 0;
	public int lastLevel = 3;

	public GameObject WinScreen;
	public GameObject LoseScreen;
	public GameObject TransitionScreen;
	public TextMeshProUGUI TransitionText;

	public static GameManager Instance;

	public Clock clock;
	public AudioSource ClickSource;
	public AudioSource DingSource;

	public const float TransiWaitTime = 1.5f;


	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);
		ClickSource = GetComponent<AudioSource>();

	}

	private void Start()
	{
		StartCoroutine(StartFirstLevel());
	}

	public IEnumerator StartFirstLevel()
	{
		clock.ResetClock();
		TransitionText.text = "Day " + (currentLevel);
		TransitionScreen.SetActive(true);
		SceneManager.LoadScene("Level_" + currentLevel, LoadSceneMode.Additive);
		yield return new WaitForSecondsRealtime(TransiWaitTime);
		TransitionScreen.SetActive(false);
		clock.ResetClock();
		yield return null;
	}

	public void WinLevel()
	{
		if (lastLevel != currentLevel)
		{
			StartCoroutine(GoToNextLevel());
		}
		else
		{
			WinScreen.SetActive(true);
		}
	}

	public IEnumerator GoToNextLevel()
	{
		clock.ResetClock();
		TransitionText.text = "Day " + (currentLevel + 1);
		TransitionScreen.SetActive(true);
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel++));
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		yield return new WaitForSecondsRealtime(TransiWaitTime);
		TransitionScreen.SetActive(false);
		clock.ResetClock();
		yield return null;
	}

	public void Reload()
	{
		ClickSource.Play();

		SceneManager.UnloadSceneAsync("Level_" + (currentLevel));
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		clock.ResetClock();
	}
	public void GoToLevel(int aLevelToGo)
	{
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel));
		currentLevel = aLevelToGo;
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		clock.ResetClock();
	}
	public void BackToMainMenu()
	{
		ClickSource.Play();
		SceneManager.LoadScene("MainMenu");
	}

	internal void Lose()
	{
		LoseScreen.SetActive(true);
	}
}
