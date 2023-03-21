using UnityEngine;
using System.Collections;

public class HealthState : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;
    public bool alive;

    

    void Start()
    {
        alive = true;
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        
    }

    public void RelivePlayer()
    {
        alive = true;        
        healthBar.SetMaxHealth(4);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }


    public void WrongDiamants()
    {
        Debug.Log("wrong diamants");
        currentHealth--;
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
           
            alive = false;
            
        }
    }

}
