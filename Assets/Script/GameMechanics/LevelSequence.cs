using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelSequence : IList<LevelAction>
{
	public Action OnActionFinished;

	public int CurrentAction;

	public int NumberOfHoursDone = 0;
	public int NumberOfHoursToDo = 5;

	public bool Validated => CurrentAction == Count;


	public void Initialize(Action aOnActionFinished)
	{
		OnActionFinished = aOnActionFinished;
		foreach (LevelAction action in this)
		{
			action.OnActionFinished = OnActionFinished;
		}
	}
	public void Reset()
	{
		foreach (LevelAction action in this)
		{
			action.Reset();
		}
		CurrentAction = 0;
	}

	#region IList Implementation

	[SerializeField]
	private List<LevelAction> Actions;

	public int IndexOf(LevelAction item)
	{
		return ((IList<LevelAction>)Actions).IndexOf(item);
	}

	public void Insert(int index, LevelAction item)
	{
		((IList<LevelAction>)Actions).Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		((IList<LevelAction>)Actions).RemoveAt(index);
	}

	public void Add(LevelAction item)
	{
		((ICollection<LevelAction>)Actions).Add(item);
	}

	public void Clear()
	{
		((ICollection<LevelAction>)Actions).Clear();
	}

	public bool Contains(LevelAction item)
	{
		return ((ICollection<LevelAction>)Actions).Contains(item);
	}

	public void CopyTo(LevelAction[] array, int arrayIndex)
	{
		((ICollection<LevelAction>)Actions).CopyTo(array, arrayIndex);
	}

	public bool Remove(LevelAction item)
	{
		return ((ICollection<LevelAction>)Actions).Remove(item);
	}

	public IEnumerator<LevelAction> GetEnumerator()
	{
		return ((IEnumerable<LevelAction>)Actions).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Actions).GetEnumerator();
	}

	public int Count => ((ICollection<LevelAction>)Actions).Count;

	public bool IsReadOnly => ((ICollection<LevelAction>)Actions).IsReadOnly;

	public LevelAction this[int index] { get => ((IList<LevelAction>)Actions)[index]; set => ((IList<LevelAction>)Actions)[index] = value; }
	#endregion

}
