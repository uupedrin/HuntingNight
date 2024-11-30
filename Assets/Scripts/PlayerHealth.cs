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

	public event Action OnPlayerDeath;
	
	private void Start()
	{
		
		StartCoroutine(LateStart());
	}
	
	IEnumerator LateStart()
	{
		yield return new WaitForEndOfFrame();
		GameManager.instance.uIManager.SetHealthText(health);
		GameManager.instance.uIManager.SetArmorText(armor);
	}
	
	public void TakeDamage(int amount)
	{
		int healthDmg = amount;
		if(armor != 0)
		{
			int armorDmg = (int)(amount * .8f);
			armor -= armorDmg;
			if(armor < 0) armor = 0;
			GameManager.instance.uIManager.SetArmorText(armor);

			healthDmg = (int)(amount * .2f);
		}
		health -= healthDmg;
			if(health <= 0) OnPlayerDeath?.Invoke();
			else GameManager.instance.uIManager.SetHealthText(health);
	}
	public void GetArmor(int amount)
	{
		armor += amount;
		if(armor > maxArmor) armor = maxArmor;
		GameManager.instance.uIManager.SetArmorText(armor);
	}
	
	public void GetSuperArmor()
	{
		armor = 200;
		GameManager.instance.uIManager.SetArmorText(armor);
	}
	
	public void GetHealth(int amount)
	{
		health += amount;
		if(health > maxHealth) health = maxHealth;
		GameManager.instance.uIManager.SetHealthText(health);
	}
}
