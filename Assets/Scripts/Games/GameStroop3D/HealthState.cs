using UnityEngine;
using System.Collections;

public class HealthState : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        
    }

    public void WrongDiamants()
    {
        Debug.Log("wrong diamants");
        currentHealth--;
        healthBar.SetHealth(currentHealth);
    }

}
