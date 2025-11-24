using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public MonsterHealth monsterHealth;


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
