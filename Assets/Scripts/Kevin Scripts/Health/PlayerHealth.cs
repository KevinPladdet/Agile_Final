using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	
	int amountOfHealing = 3;

	public HealthBar healthBar;


	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20); // Each time the player gets hit he loses 20 health (The player can take 5 hits before dying)
			// Currently the player takes damage when spacebar is pressed, but the same person who makes the enemies will link this together
		}

		if ((GameObject.Find("Main Camera").GetComponent<Inventory>().PlayerGotHealed) && amountOfHealing >=1)
		{
			Heal();
			amountOfHealing--; // This makes it so that the player can only heal 3 times
			GameObject.Find("Main Camera").GetComponent<Inventory>().PlayerGotHealed = false;
		}

		if (currentHealth == 0)
        {
			SceneManager.LoadScene("Death Menu"); // If the player reaches 0 health, he gets send to the Death Menu
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
