using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	[SerializeField] Transform initialPoint;
	[SerializeField] Transform finalPoint;
	[SerializeField] float elevatorSpeed;
	public bool canMove = true;
	bool goingUp = true;
	private void OnTriggerEnter(Collider other)
	{
		other.transform.parent = transform;
	}
	
	private void OnTriggerExit(Collider other)
	{
		other.transform.parent = null;
	}
	
	private void Update()
	{
		if(canMove)
		{
			if(goingUp)
			{
				transform.Translate(Vector3.up * Time.deltaTime * elevatorSpeed);
				if(Vector3.Distance(transform.position, finalPoint.position) < 0.01f)
				{
					goingUp = false;
				}
			}
			else
			{
				transform.Translate(Vector3.down * Time.deltaTime * elevatorSpeed);
				if(Vector3.Distance(transform.position, initialPoint.position) < 0.01f)
				{
					goingUp = true;
				}
			}	
		}
	}
}
