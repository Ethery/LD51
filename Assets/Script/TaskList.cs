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
		if (currentPlayer != null && currentPlayer.CurrentSequence != null && !currentPlayer.clock.IsOK)
		{
			int i = 0;
			foreach (LevelAction action in currentPlayer.CurrentSequence)
			{
				if (action is DialogueAction)
					continue;

				GameObject gameObject = null;
				if (TaskContainer.childCount <= i)
				{
					gameObject = Instantiate(PrefabTask, TaskContainer);
				}
				else
				{
					gameObject = TaskContainer.GetChild(i).gameObject;
				}

				gameObject.GetComponent<TextMeshProUGUI>().text = action.ToString();
				gameObject.SetActive(true);
				if (i < currentPlayer.CurrentSequence.CurrentAction)
					gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
				else
					gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
				i++;
			}
			for (; i < TaskContainer.childCount; i++)
			{
				TaskContainer.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
