using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorUtilities : ScriptableObject
{
	static List<Scene> CurrentScenes = new List<Scene>();

	[MenuItem("Tools/Launch game %g")]
	static void Open()
	{
		SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/MainMenu.unity");
		if (myWantedStartScene != null)
			EditorSceneManager.playModeStartScene = myWantedStartScene;
		else
			Debug.Log("Could not find Scene Assets/Scenes/MainMenu.unity");
		EditorApplication.isPlaying = true;
	}
}