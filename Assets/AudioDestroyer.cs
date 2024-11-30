using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDestroyer : MonoBehaviour
{
	AudioSource _source;
	
	private void Awake()
	{
		_source = GetComponent<AudioSource>();
	}
	
	private void Start()
	{
		StartCoroutine(Destroyer());
	}
	
	IEnumerator Destroyer()
	{
		yield return new WaitForSeconds(_source.clip.length);
		Destroy(gameObject);
	}
}
