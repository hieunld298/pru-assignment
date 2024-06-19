using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamege(int damage)
    {
        currentHealth-=damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamege(1);
        }
    }
}
