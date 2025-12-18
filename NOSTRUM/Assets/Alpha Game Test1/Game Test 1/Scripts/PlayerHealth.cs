using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

public void TakeDamage(int damage) 
    { 
        health -= damage;

        if (health <= 0) 
        { 
            Destroy(gameObject);
        }
    }
public void Changehealth (int amount) 
    { 
        health += amount;
        if (health > maxHealth) 
            health = maxHealth;

    }
}
