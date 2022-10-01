using System.Collections;
using UnityEngine;

public class LevelSequencePlayer : MonoBehaviour
{
	public LevelSequence LevelSequence;
	public int CurrentAction;

	public void GoToNextAction()
	{
		CurrentAction++;
	}

	private void Start()
	{
		LevelSequence.Initialize(GoToNextAction);
	}
}