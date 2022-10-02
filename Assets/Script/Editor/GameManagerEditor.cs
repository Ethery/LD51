using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolsWindow : EditorWindow
{
	[MenuItem("Tools/Window")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(ToolsWindow));
	}

	public void OnGUI()
	{
		if (GameManager.Instance != null)
		{
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("PreviousLevel"))
			{
				GameManager.Instance.GoToLevel(GameManager.Instance.currentLevel - 1);
			}
			if (GUILayout.Button("NextLevel"))
			{
				GameManager.Instance.WinLevel();
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Slow"))
			{
				Time.timeScale = 0.25f;
			}
			if (GUILayout.Button("Normal"))
			{
				Time.timeScale = 1f;
			}
			if (GUILayout.Button("Fast"))
			{
				Time.timeScale = 2f;
			}

			EditorGUILayout.EndHorizontal();
		}

	}
}
