using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction : LevelAction
{
	public Slider Slider;

	protected override void StartActionSpecific()
	{
		Slider.interactable = true;
		Slider.value = 0;
	}
	protected override void FinishActionSpecific()
	{
		Slider.interactable = false;
	}
	protected override void ResetActionSpecific()
	{
		Slider.interactable = false;
	}

	private void Update()
	{
		if (Slider.interactable)
		{
			if (Slider.value >= 1)
				FinishAction();
		}
	}

}