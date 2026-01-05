using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Checkpoint");
        }
    }
}
