using JetBrains.Annotations;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Clock : MonoBehaviour
{
	[HideInInspector]
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

		Animator.SetBool("IsOk", IsOK);
	}
}