using System;
using System.Collections;
using UnityEngine;

[Serializable]
public abstract class LevelAction : MonoBehaviour
{
	public bool HiddenByDefault;
	public bool HideOnCompletion;

	public Action OnActionFinished;

	[HideInInspector]
	public EActionStatus Status;

	public enum EActionStatus
	{
		Disabled,
		Started,
		Finished
	}

	public void StartAction()
	{
		StartActionSpecific();
		Status = EActionStatus.Started;
	}
	protected abstract void StartActionSpecific();

	public void FinishAction()
	{
		if (Status == EActionStatus.Started)
		{
			if (HideOnCompletion)
				gameObject.SetActive(false);

			FinishActionSpecific();

			OnActionFinished();
			Status = EActionStatus.Finished;
		}
		else if (Status == EActionStatus.Finished)
        {
			OnActionFinished();
        }
	}

	protected abstract void FinishActionSpecific();

	public void ResetAction()
	{
		gameObject.SetActive(!HiddenByDefault);
		ResetActionSpecific();
		Status = EActionStatus.Disabled;
	}
	protected abstract void ResetActionSpecific();

}