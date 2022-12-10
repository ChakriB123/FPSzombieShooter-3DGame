using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public float currentHealth;

	public HealthBar healthBar;
	public static bool isGameOver;

   
    GameObject GamePanel;
    GameObject GameOverPanel;

   

    // Start is called before the first frame update
    void Start()
    {
     

        GamePanel = GameObject.Find("GamePlayPanel");
        GameOverPanel = GameObject.Find("GameOverPanel");
        
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        isGameOver = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
		if(isGameOver == true)
		{
            Cursor.lockState = CursorLockMode.None;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(false);
           
        }
    }

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if(currentHealth <= 0)
		{
			isGameOver = true;
		}
	}
}
