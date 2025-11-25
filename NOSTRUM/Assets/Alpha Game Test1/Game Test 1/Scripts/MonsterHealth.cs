using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Action OnDamaged;
    public Action OnDeath;

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

}

