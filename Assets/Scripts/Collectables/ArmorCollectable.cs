using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorCollectable : ICollectable
{
	[SerializeField] int armorIncreaseAmount;
	[SerializeField] bool UltraArmor = false;
	public override void Effect(Collider other)
	{
		if(armorIncreaseAmount == 0) armorIncreaseAmount = (int)Random.Range(4,10);
		if(UltraArmor) other.GetComponent<PlayerHealth>().GetSuperArmor();
		else other.GetComponent<PlayerHealth>().GetArmor(armorIncreaseAmount);
	}
}
