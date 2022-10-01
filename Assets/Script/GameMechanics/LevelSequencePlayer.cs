using System.Collections;
using UnityEngine;

public class LevelSequencePlayer : MonoBehaviour
{
	public LevelSequence LevelSequence;
	public int CurrentAction;

	public Clock clock => GameManager.Instance.clock;

	public void GoToNextAction()
	{
		CurrentAction++;
		LevelSequence[CurrentAction].StartAction();
	}

	private void Start()
	{
		LevelSequence.Initialize(GoToNextAction);
	}

	public void Update()
	{
		if (clock.CurrentTime / 10 == CurrentAction)
		{
			clock.IsOK = true;
		}
	}
}