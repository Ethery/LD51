using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTask : LevelAction
{
	public string Text;
	public override string ToString()
	{
		return Text;
	}

	protected override void FinishActionSpecific()
	{
	}

	protected override void ResetActionSpecific()
	{
	}

	protected override void StartActionSpecific()
	{
		FinishAction();
	}
}
