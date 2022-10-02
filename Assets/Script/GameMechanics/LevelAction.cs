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

	public Diode DisabledDiode;
	public Diode StartedDiode;
	public Diode FinishedDiode;

	public enum EActionStatus
	{
		Disabled,
		Started,
		Finished
	}

	private void Update()
	{
		if (DisabledDiode != null)
		{
			DisabledDiode.On = Status == EActionStatus.Disabled;
			DisabledDiode.color = Color.red;
		}

		if (StartedDiode != null)
		{
			StartedDiode.On = Status == EActionStatus.Started;
			StartedDiode.color = (Color.red + Color.yellow) / 2;
		}

		if (FinishedDiode != null)
		{
			FinishedDiode.On = Status == EActionStatus.Finished;
			FinishedDiode.color = Color.green;
		}
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
		else if (Status == EActionStatus.Finished)
        {
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