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
	public AudioSource source;

	public const float TransiWaitTime = 1.5f;


	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);
		source = GetComponent<AudioSource>();

	}

	private void Start()
	{
		StartCoroutine(StartFirstLevel());
	}

	public IEnumerator StartFirstLevel()
	{
		clock.Reset();
		TransitionText.text = "Day " + (currentLevel);
		TransitionScreen.SetActive(true);
		SceneManager.LoadScene("Level_" + currentLevel, LoadSceneMode.Additive);
		yield return new WaitForSecondsRealtime(TransiWaitTime);
		TransitionScreen.SetActive(false);
		clock.Reset();
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
		clock.Reset();
		TransitionText.text = "Day " + (currentLevel + 1);
		TransitionScreen.SetActive(true);
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel++));
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		yield return new WaitForSecondsRealtime(TransiWaitTime);
		TransitionScreen.SetActive(false);
		clock.Reset();
		yield return null;
	}

	public void Reload()
	{
		source.Play();

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
		source.Play();
		SceneManager.LoadScene("MainMenu");
	}

	internal void Lose()
	{
		LoseScreen.SetActive(true);
	}
}
