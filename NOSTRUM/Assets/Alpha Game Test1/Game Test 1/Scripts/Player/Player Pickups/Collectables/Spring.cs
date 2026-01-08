using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private AudioSource SpringSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Spring += 1;
            Destroy(gameObject);
           
            SpringSound.Play();
        }
    }
}
