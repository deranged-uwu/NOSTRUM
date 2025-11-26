using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public MonsterHealth monsterHealth;
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            monsterHealth.TakeDamage(damage);
        }
    }
}
