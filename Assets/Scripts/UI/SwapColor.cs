using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SwapColor : MonoBehaviour, ISelectHandler, IDeselectHandler
{
	[SerializeField] private TMP_Text textPro;
	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		textPro.color = new Color(255, 255, 255);
	}
 
	public void OnDeselect(BaseEventData eventData)
	{
		textPro.color = new Color(255, 0, 106);
	}
}
