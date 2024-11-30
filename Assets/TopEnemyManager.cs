using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEnemyManager : MonoBehaviour
{
	public static TopEnemyManager instance;
	[SerializeField] GameObject card;
	private void Awake()
	{
		if(instance is null)
		{
			instance = this;
		}
	}
	
	private void OnDestroy()
	{
		instance = null;
		card.SetActive(true);
	}
	
	public List<GameObject> enemies;
	
	private void FixedUpdate()
	{
		if(enemies.Count == 0)
		{
			card.SetActive(true);
			Destroy(gameObject);
		}
	}
}
