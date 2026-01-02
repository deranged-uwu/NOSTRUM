using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{
    private Vector3 lastPosition;
    public int maxHealth = 4;
    public int health;
    public string levelToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health <= 0)
        {
            transform.position = lastPosition;
            SceneManager.LoadScene(levelToLoad);
        }

        if (collision.CompareTag("CheckPoint"))
        {
            lastPosition = transform.position;
        }
    }
}