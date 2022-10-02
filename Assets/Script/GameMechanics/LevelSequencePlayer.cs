using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSequencePlayer : MonoBehaviour
{
	public List<ActionSequence> ActionSequences;
	public int CurrentHour = 0;

	public ActionSequence CurrentSequence
	{
		get
		{
			if (ActionSequences.Count > CurrentHour)
				return ActionSequences[CurrentHour];
			else
				return null;
		}
	}
	public Clock clock => GameManager.Instance.clock;


	private void Start()
	{
		CurrentSequence.Initialize();
	}


	public float lastTimeValidated = -1;

	public void Update()
	{
		if (lastTimeValidated > clock.CurrentTime)
		{
			lastTimeValidated = -1;
			CurrentSequence.Initialize();
		}
		if (!clock.IsOK)
		{
			if (CurrentSequence.Validated)
			{
				clock.IsOK = true;
				CurrentHour++;
				lastTimeValidated = clock.CurrentTime;
			}
		}

		if (CurrentHour >= ActionSequences.Count)
		{
			GameManager.Instance.WinLevel();
		}
	}
}