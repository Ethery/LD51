using JetBrains.Annotations;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Clock : MonoBehaviour
{
	[ReadOnly(true)]
	public float CurrentTime;

	private Animator Animator => GetComponent<Animator>();

	[ReadOnly(true)]
	public bool IsOK;


	public void FixedUpdate()
	{
		CurrentTime += Time.fixedDeltaTime;
		if (CurrentTime > 10)
		{
			if (IsOK)
			{
				IsOK = false;
				ResetClock();
			}
			else
			{
				GameManager.Instance.Lose();
			}
		}
		Animator.SetBool("IsOk", IsOK);
	}

	[ContextMenu("Reset Clock")]
	public void ResetClock()
	{
		CurrentTime = 0;
		IsOK = false;
		Animator.SetTrigger("Reset");
	}
}