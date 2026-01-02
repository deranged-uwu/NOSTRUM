using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public float waitTime = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Alpha Game Test1/Game Test 1/Scenes/Levels/Floor 2-2", (LoadSceneMode)waitTime);
        }
    }
}