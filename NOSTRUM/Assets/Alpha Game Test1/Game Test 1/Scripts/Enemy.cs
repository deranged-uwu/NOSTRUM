using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public MonsterHealth monsterHealth;

    public float speed = 2.5f;
    private float direction = 1f;

    private void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Barrier"))
        {
            direction *= -1;
            transform.localScale = new Vector3(direction,1,1);
        }
    }

    private void OnEnable()
    {
        monsterHealth.OnDamaged += HandleDamage;
    }

    private void OnDisable()
    {
        monsterHealth.OnDamaged -= HandleDamage;
    }

    void HandleDamage()
    {
        anim.SetTrigger("Hurt");
    }

}
