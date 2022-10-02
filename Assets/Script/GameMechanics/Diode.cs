using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diode : MonoBehaviour
{
	public Color color;

	public bool On;

	public Color GetColorFromParam()
	{
		Color newColor = color - (On ? Color.black : Color.white);
		newColor.a = 1;
		return newColor;
	}

	private void Update()
	{
		GetComponent<Image>().color = GetColorFromParam();
	}

}
