using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private int numOfEnemies = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            numOfEnemies -= 1;
            Debug.Log("Enemies left: " + numOfEnemies);
            if (numOfEnemies == 0)
            {
                Debug.Log("Enemies over");
                Invoke("NextScene", 3f);
            }
        }
    }
    void NextScene()
    {
        SceneManager.LoadScene("Alpha Game Test1/Game Test 1/Scenes/Floor 1-1");
    }

}