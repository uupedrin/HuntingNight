using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text ammoText;
	[SerializeField] TMP_Text armorText;
	[SerializeField] TMP_Text healthText;
	[SerializeField] Image keyCard;
	[SerializeField] GameObject victoryPanel;
	
	private void Start()
	{
		GameManager.instance.uIManager = this;
	}
	
	public void SetAmmoText(int ammo)
	{
		ammoText.text = $"Ammo: {ammo}";
	}
	public void SetHealthText(int health)
	{
		healthText.text = $"Health: {health}";
	}
	public void SetArmorText(int armor)
	{
		armorText.text = $"Armor: {armor}";
	}
	
	public void ShowCard()
	{
		keyCard.gameObject.SetActive(true);
	}
	
	public void Win()
	{
		victoryPanel.SetActive(true);
	}
}
