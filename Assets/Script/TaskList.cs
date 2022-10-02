using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskList : MonoBehaviour
{
	public GameObject PrefabTask;
	public Transform TaskContainer;
	LevelSequencePlayer currentPlayer;
	private void Update()
	{
		currentPlayer = FindObjectOfType<LevelSequencePlayer>();
		if (currentPlayer != null && currentPlayer.CurrentSequence != null)
		{
			int i = 0;
			foreach (LevelAction action in currentPlayer.CurrentSequence)
			{
				GameObject gameObject = null;
				if (TaskContainer.childCount <= i)
				{
					gameObject = Instantiate(PrefabTask, TaskContainer);
				}
				else
				{
					gameObject = TaskContainer.GetChild(0).gameObject;
				}

				gameObject.GetComponent<TextMeshProUGUI>().text = action.ToString();

				i++;
			}
			for (; i < TaskContainer.childCount; i++)
			{
				TaskContainer.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
