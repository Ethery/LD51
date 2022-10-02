using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : LevelAction
{
	public Button button;

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
	}

    private void Awake()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(FinishAction);
    }

}