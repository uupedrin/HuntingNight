using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardCollectable : ICollectable
{
	[SerializeField] GameObject[] toDisable;

	public override void Effect(Collider other)
	{
		for (int i = 0; i < toDisable.Length; i++)
		{
			toDisable[i].SetActive(false);
		}
		GameManager.instance.uIManager.ShowCard();
	}
	
}
