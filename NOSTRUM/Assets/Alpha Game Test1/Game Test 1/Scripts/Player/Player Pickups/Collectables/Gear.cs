using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private AudioSource GearSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Gear += 1;
            Destroy(gameObject);
           
            GearSound.Play();
        }
    }
}