using JetBrains.Annotations;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Clock : MonoBehaviour
{
	[ReadOnly(true)]
	public float CurrentTime;

	private Animator Animator;

	[ReadOnly(true)]
	public bool IsOK;

	private void Start()
	{
		Animator = GetComponent<Animator>();
	}

	public void Update()
	{
		CurrentTime += Time.fixedDeltaTime;
		if (CurrentTime > 10)
		{
			if (IsOK)
			{
				CurrentTime = 0;
				IsOK = false;
			}
			else
			{
				Debug.Log("Lose");
				//GameManager.Instance.Lose();
			}
		}
		Animator.SetBool("IsOk", IsOK);
	}

	[ContextMenu("Reset Clock")]
	public void Reset()
	{
		CurrentTime = 0;
	}
}