using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public float waitTime = 2f;
    public string levelToLoad;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("LevelToLoad", waitTime);
            anim.SetTrigger("DoorOpen");
        }
    }
    private void LevelToLoad()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}