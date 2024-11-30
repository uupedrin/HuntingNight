using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : ICollectable
{
    [SerializeField] int healthIncreaseAmount;
	public override void Effect(Collider other)
	{
		if(healthIncreaseAmount == 0) healthIncreaseAmount = (int)Random.Range(4,10);
		other.GetComponent<PlayerHealth>().GetHealth(healthIncreaseAmount);
	}
}
