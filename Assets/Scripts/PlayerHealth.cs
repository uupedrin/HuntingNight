using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] int armor;
	[SerializeField] int maxArmor;
	[SerializeField] int health;
	[SerializeField] int maxHealth;

	public event Action<int> OnArmorValueChange;
	public event Action<int> OnHealthValueChange;
	public event Action OnPlayerDeath;
	
	public void TakeDamage(int amount)
	{
		int healthDmg = amount;
		if(armor != 0)
		{
			int armorDmg = (int)(amount * .8f);
			armor -= armorDmg;
			if(armor < 0) armor = 0;
			OnArmorValueChange?.Invoke(armor);

			healthDmg = (int)(amount * .2f);
		}
		health -= healthDmg;
			if(health <= 0) OnPlayerDeath?.Invoke();
			else OnHealthValueChange?.Invoke(health);
	}
	public void GetArmor(int amount)
	{
		armor += amount;
		if(armor > maxArmor) armor = maxArmor;
		OnArmorValueChange(armor);
	}
	
	public void GetHealth(int amount)
	{
		health += amount;
		if(health > maxHealth) health = maxHealth;
		OnHealthValueChange(health);
	}
}
