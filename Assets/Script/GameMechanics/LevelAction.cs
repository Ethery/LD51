using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class LevelAction : MonoBehaviour
{
	public bool HideOnCompletion;

	public Action OnActionFinished;


	public void FinishAction()
	{
		if (HideOnCompletion)
			gameObject.SetActive(false);

		OnActionFinished();
	}

	public void StartAction()
	{
		gameObject.SetActive(true);
	}
}