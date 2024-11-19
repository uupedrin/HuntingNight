using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
	[SerializeField] int health;
	
	public void TakeDamage(int amount)
	{
		health -= amount;
		if(health <= 0)
		{
			Die();
		}
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
