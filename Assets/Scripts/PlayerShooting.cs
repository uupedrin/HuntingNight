using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[Header("Aim")]
	Vector3 rayOrigin = new Vector3(0.5f,0.5f,0f);
	float rayLength = 500f;
	Ray ray;
	
	[Header("Weapon Properties")]
	[SerializeField] int ammo = 50;
	[SerializeField] int maxAmmo = 999;
	[SerializeField] float fireRate;
	bool canFire = true;
	
	[Header("References")]
	[SerializeField] GameObject mesh;
	[SerializeField] GameObject shootAudio;
	[SerializeField] GameObject missShootAudio;
	
	private void Start()
	{
		StartCoroutine(LateStart());
	}
	
	private void OnEnable()
	{
		mesh.SetActive(true);
	}
	
	private void OnDisable()
	{
		mesh.SetActive(false);
	}
	
	IEnumerator LateStart()
	{
		yield return new WaitForEndOfFrame();
		GameManager.instance.uIManager.SetAmmoText(ammo);
	}
	
	public void IncreaseAmmo(int amount)
	{
		ammo += amount;
		if(ammo > maxAmmo) ammo = maxAmmo;
		GameManager.instance.uIManager.SetAmmoText(ammo);
	}
	
	private void Update()
	{
		if(Input.GetMouseButton(0))
		{
			Fire();
		}
	}
	private void Fire()
	{
		if(canFire)
		{
			canFire = false;
			if(ammo > 0) Shoot();
			else Instantiate(missShootAudio);
			StartCoroutine(ResetFire());
		}
	}
	
	IEnumerator ResetFire()
	{
		yield return new WaitForSeconds(fireRate);
		canFire = true;
	}
	
	private void Shoot()
	{
		ammo--;
		if(ammo < 0) ammo = 0;
		
		Instantiate(shootAudio);
		
		GameManager.instance.uIManager.SetAmmoText(ammo);
		
		ray = Camera.main.ViewportPointToRay(rayOrigin);
		
		Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, rayLength))
		{
			if(hit.transform.gameObject.TryGetComponent<IDamageable>(out IDamageable damager))
			{
				damager.TakeDamage(1);
			}
		}
	}
}
