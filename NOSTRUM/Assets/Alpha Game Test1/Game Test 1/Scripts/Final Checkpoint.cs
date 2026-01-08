using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCheckpoint : MonoBehaviour
{
    [SerializeField] private AudioSource RestSound;
    
    public Animator anim;
    public float waitTime = 10f;
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Checkpoint");
            
            RestSound.Play();
            
            Invoke("LevelToLoad", waitTime);
        }
    }
    private void LevelToLoad()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    
}
