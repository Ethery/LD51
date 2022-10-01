using System;
using System.Collections;
using UnityEngine;

public class LevelAction : MonoBehaviour
{
	public GameObject objectToDisplay;
	public bool HideOnCompletion;

	public Action OnActionFinished;


	public void FinishAction()
	{
		if (HideOnCompletion)
			objectToDisplay.SetActive(false);

		OnActionFinished();
	}

	public void StartAction()
	{
		objectToDisplay.SetActive(true);
	}
}