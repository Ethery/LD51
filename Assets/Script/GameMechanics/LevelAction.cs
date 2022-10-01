using System;
using System.Collections;
using UnityEngine;

[Serializable]
public abstract class LevelAction : MonoBehaviour
{
	public bool HiddenByDefault;
	public bool HideOnCompletion;

	public Action OnActionFinished;

	public EActionStatus Status;

	public enum EActionStatus
	{
		Disabled,
		Started,
		Finished
	}

	public void StartAction()
	{
		if (Status == EActionStatus.Disabled)
		{
			Status = EActionStatus.Started;
			gameObject.SetActive(true);
			StartActionSpecific();
		}
	}
	protected abstract void StartActionSpecific();

	public void FinishAction()
	{
		if (Status == EActionStatus.Started)
		{
			Status = EActionStatus.Finished;
			if (HideOnCompletion)
				gameObject.SetActive(false);

			FinishActionSpecific();

			OnActionFinished();
		}
	}

	protected abstract void FinishActionSpecific();

	public void ResetAction()
	{
		if (Status == EActionStatus.Finished)
		{
			Status = EActionStatus.Disabled;
			gameObject.SetActive(!HiddenByDefault && !HideOnCompletion);
			ResetActionSpecific();
		}
	}
	protected abstract void ResetActionSpecific();

}