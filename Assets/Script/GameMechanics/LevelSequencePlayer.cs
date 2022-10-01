using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSequencePlayer : MonoBehaviour
{
	public List<ActionSequence> ActionSequences;
	public int CurrentHour = 0;

	public ActionSequence LevelSequence => ActionSequences[CurrentHour];
	public Clock clock => GameManager.Instance.clock;


	private void Start()
	{
		LevelSequence.Initialize();
	}


	public float lastTimeValidated = -1;

	public void Update()
	{
		if (lastTimeValidated > clock.CurrentTime)
		{
			lastTimeValidated = -1;
			LevelSequence.Initialize();
		}
		if (!clock.IsOK)
		{
			if (LevelSequence.Validated)
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