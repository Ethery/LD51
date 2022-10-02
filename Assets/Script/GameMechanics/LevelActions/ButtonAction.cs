using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : LevelAction
{
	public Button button;
	private int PushCount = 0;
	public List<int> PushObjectives = new List<int>() { 1 };
	public int PushObjective => PushObjectives[CurrentObjective];

	private int CurrentObjective = 0;
	public TextMeshProUGUI buttonName;

	public void PushedButtonOnce()
	{
		PushCount++;
		if (PushCount >= PushObjective)
		{
			FinishAction();
		}
	}

	protected override void FinishActionSpecific()
	{
		button.interactable = false;
	}
	protected override void ResetActionSpecific()
	{
		button.interactable = false;
		if (PushObjectives.Count > CurrentObjective + 1)
			CurrentObjective++;
	}
	protected override void StartActionSpecific()
	{
		button.interactable = true;
		button = GetComponentInChildren<Button>();
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(PushedButtonOnce);
		PushCount = 0;
	}

	private void Awake()
	{

		buttonName = GetComponentInChildren<TextMeshProUGUI>();
		buttonName.text = name;
	}
	public override string ToString()
	{
		if (CurrentObjective != -1)
			return $"Push the button {name} {PushObjective} times";
		else
			return string.Empty;
	}
}
