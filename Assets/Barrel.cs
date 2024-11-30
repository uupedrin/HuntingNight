using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamageable
{
	[SerializeField] Elevator elevator;
	[SerializeField] GameObject rocks;
	[SerializeField] float barrelRespawnTime;
	
	[SerializeField] GameObject[] mesh;
	[SerializeField] Collider col;
	
	PlayerHealth playerHealth;

	public void TakeDamage(int amount)
	{
		rocks.SetActive(false);
		elevator.canMove = true;
		if(playerHealth != null) 
		{
			playerHealth.TakeDamage(20);
		}
		Deactivate();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		playerHealth = other.GetComponent<PlayerHealth>();
	}
	
	private void OnTriggerExit(Collider other)
	{
		playerHealth = null;
	}
	
	private void Deactivate()
	{
		for (int i = 0; i < mesh.Length; i++)
		{
			mesh[i].SetActive(false);
		}
		col.enabled = false;
		StartCoroutine(Respawn());
	}
	
	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(barrelRespawnTime);
		Activate();
	}
	
	private void Activate()
	{
		for (int i = 0; i < mesh.Length; i++)
		{
			mesh[i].SetActive(true);
		}
		col.enabled = true;
	}
	
	private void OnDisable()
	{
		
		playerHealth = null;
	}
}
