using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public UIManager uIManager;
	
	private void Awake()
	{
		if(instance is null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	private void OnDestroy()
	{
		if(instance == this) instance = null;
	}
}
