using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelSequence")]
public class LevelSequence : ScriptableObject, IList<LevelAction>
{
	public Action OnActionFinished;

	public void Initialize(Action aOnActionFinished)
	{
		OnActionFinished = aOnActionFinished;
		foreach (LevelAction action in this)
		{
			action.OnActionFinished = OnActionFinished;
		}
	}

	#region IList Implementation
	public LevelAction this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public int Count => throw new NotImplementedException();

	public bool IsReadOnly => throw new NotImplementedException();

	public void Add(LevelAction item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(LevelAction item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(LevelAction[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<LevelAction> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public int IndexOf(LevelAction item)
	{
		throw new NotImplementedException();
	}


	public void Insert(int index, LevelAction item)
	{
		throw new NotImplementedException();
	}

	public bool Remove(LevelAction item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
	#endregion

}
