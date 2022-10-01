using System;
using System.Collections;
using UnityEngine;

public class LevelAction : MonoBehaviour
{
	public GameObject objectToDisplay;
	public bool HideOnCompletion;

	public Action OnActionFinished;

	public void ToggleObject()
	{
		objectToDisplay.SetActive(!objectToDisplay.activeSelf);
	}

	public void FinishAction()
	{
		if (HideOnCompletion)
			ToggleObject();

		OnActionFinished();
	}
}