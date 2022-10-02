using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int currentLevel = 1;
	public int lastLevel = 3;

	public GameObject WinScreen;
	public GameObject LoseScreen;
	public GameObject TransitionScreen;
	public TextMeshProUGUI TransitionText;

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
			StartCoroutine(SwitchLevel());
		}
		else
		{
			WinScreen.SetActive(true);
		}
	}

	public IEnumerator SwitchLevel()
	{
		clock.Reset();
		TransitionText.text = "Day " + (currentLevel + 1);
		TransitionScreen.SetActive(true);
		SceneManager.UnloadSceneAsync("Level_" + (currentLevel++));
		SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
		yield return new WaitForSecondsRealtime(3);
		TransitionScreen.SetActive(false);
		clock.Reset();
		yield return null;
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
