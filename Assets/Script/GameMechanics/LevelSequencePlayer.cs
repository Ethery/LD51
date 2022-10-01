using System.Collections;
using UnityEngine;

public class LevelSequencePlayer : MonoBehaviour
{
	public LevelSequence LevelSequence;
	public Clock clock => GameManager.Instance.clock;

	public void GoToNextAction()
	{
		LevelSequence.CurrentAction++;
		if (LevelSequence.CurrentAction < LevelSequence.Count)
		{
			LevelSequence[LevelSequence.CurrentAction].StartAction();
		}
	}

	private void Start()
	{
		LevelSequence.Initialize(GoToNextAction);
	}

	public int amountOfValidation = 0;
	public float lastTimeValidated = -1;
	public void Update()
	{
		if (lastTimeValidated > clock.CurrentTime)
		{
			lastTimeValidated = -1;
			LevelSequence.Reset();
		}
		if (!clock.IsOK)
		{
			if (LevelSequence.Validated)
			{
				clock.IsOK = true;
				amountOfValidation++;
				lastTimeValidated = clock.CurrentTime;
			}
		}
	}
}