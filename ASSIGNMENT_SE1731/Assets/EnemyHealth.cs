using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth;
        slider.value = CalculateHealth();
        healthBarUI.SetActive(false); // Initially hide the health bar UI
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        slider.value = CalculateHealth();
    }


}
