using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public MonsterHealth monsterHealth;
    private int damage = 1;

    public void Update()
    {
        //Debug.Log("Attack Area Active");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("checking collision");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
            monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.TakeDamage(damage);
        }
    }
}
