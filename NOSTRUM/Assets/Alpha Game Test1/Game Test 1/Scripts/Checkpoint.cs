using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioSource RestSound;
    
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Checkpoint");
            
            RestSound.Play();
        }
    }
}
