using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	//public inventoryScript invS;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//what happens when player gets hit (player can take 5 hits before dying)
			TakeDamage(20);
		}

		//if (invS.PlayerGotHealed = true)
        {
			//Debug.Log(invS.PlayerGotHealed);
			Heal();
			//invS.PlayerGotHealed = false;
			//Debug.Log(invS.PlayerGotHealed);
		}

		if (currentHealth == 0)
        {
			//what happens when health reaches 0
			SceneManager.LoadScene("Death Menu");
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	void Heal()
	{
		currentHealth += 40;

		healthBar.SetHealth(currentHealth);
	}
}
