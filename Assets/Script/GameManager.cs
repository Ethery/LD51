using System.Linq;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [ReadOnly]
    public int currentLevel = 1;
    public int lastLevel = 3;

    public GameObject WinScreen;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        WinScreen.SetActive(false);

	}

    private void Start()
    {
        SceneManager.LoadScene("Level_"+currentLevel,LoadSceneMode.Additive);
    }

	public void GoToNextLevel()
	{
		if (lastLevel != currentLevel)
		{
			SceneManager.UnloadSceneAsync("Level_" + (currentLevel++));
			SceneManager.LoadScene("Level_" + (currentLevel), LoadSceneMode.Additive);
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
	}

	public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
