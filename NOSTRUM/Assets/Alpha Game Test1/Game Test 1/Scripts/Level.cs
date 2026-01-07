using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int numberofRatsInLevel;
    public int deadRatCount = 0;
    public string levelToLoad;
    public float levelDelay = 3f;

    public void RatDied()
    {
        deadRatCount++;
        if (deadRatCount == numberofRatsInLevel)
        { 
            Invoke("LevelToLoad", levelDelay);
        }
    }
    private void LevelToLoad()
    { 
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
