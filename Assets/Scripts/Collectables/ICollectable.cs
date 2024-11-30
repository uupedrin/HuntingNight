using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollectable : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Effect(other);
		Destroy(gameObject);
	}
	
	public virtual void Effect(Collider other)
	{
		Debug.Log("Effect");
	}
}