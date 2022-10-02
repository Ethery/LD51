using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : LevelAction
{
	public Button button;
	public int PushCount = 0;
	public List<int> PushObjectives = new List<int>() { 1 };
	public int PushObjective => PushObjectives[CurrentObjective];
	public int CurrentObjective = -1;
	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(() =>
		{
			PushCount++;
			if (PushCount >= PushObjective)
				FinishAction();
		});
	}
	protected override void FinishActionSpecific()
	{
		button.interactable = false;
	}
	protected override void ResetActionSpecific()
	{
		button.interactable = false;
	}
	protected override void StartActionSpecific()
	{
		button.interactable = true;
		PushCount = 0;
		if (PushObjectives.Count > CurrentObjective + 1)
			CurrentObjective++;
	}
	public override string ToString()
	{
		return $"Push the button {PushObjective} times";
	}
}