using System.Collections;
using UnityEngine;

namespace Assets.Script
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}