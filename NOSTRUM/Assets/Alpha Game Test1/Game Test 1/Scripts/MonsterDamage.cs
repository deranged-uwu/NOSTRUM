using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerTriggers playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
