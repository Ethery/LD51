using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
	public float CurrentTime;

	public Animator Animator;
	internal bool IsOK;

	public void Update()
	{
		CurrentTime += Time.fixedDeltaTime;

		Animator.SetBool("IsOk", IsOK);
	}
}