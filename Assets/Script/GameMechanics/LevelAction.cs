using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class LevelAction : MonoBehaviour
{

	public bool HiddenByDefault;
	public bool HideOnCompletion;

	public Action OnActionFinished;

	public bool IsFinished;


	public void FinishAction()
	{
		if (!IsFinished)
		{
			if (HideOnCompletion)
				gameObject.SetActive(false);

			OnActionFinished();
			IsFinished = true;
		}
	}

	public void StartAction()
	{
		gameObject.SetActive(true);
	}

	public void Reset()
	{
		gameObject.SetActive(!HiddenByDefault);
	}
}