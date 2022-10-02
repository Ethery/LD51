using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction : LevelAction
{
	public Slider Slider;
	public TextMeshProUGUI sliderName;



	protected override void StartActionSpecific()
	{
		Slider.interactable = true;
	}
	protected override void FinishActionSpecific()
	{
		Slider.interactable = false;
	}
	protected override void ResetActionSpecific()
	{
		Slider.interactable = false;
		Slider.value = 0;
	}

	private void Update()
	{
		if (Slider.interactable)
		{
			if (Slider.value >= 1)
				FinishAction();
		}
		sliderName.text = name;
	}


	public override string ToString()
	{
		return $"Max out the slider " + name;
	}
}