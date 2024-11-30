using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectable : ICollectable
{
	[SerializeField] int ammoIncreaseAmount;
	public override void Effect(Collider other)
	{
		if(ammoIncreaseAmount == 0) ammoIncreaseAmount = (int)Random.Range(4,10);
		other.GetComponent<PlayerShooting>().IncreaseAmmo(ammoIncreaseAmount);
	}
	
}
