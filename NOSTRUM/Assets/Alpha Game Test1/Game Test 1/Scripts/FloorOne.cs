using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorOne : MonoBehaviour
{
    private int numOfEnemies = 3;
    public string nextScene;
    private float Count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene(nextScene);
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
        SceneManager.LoadScene("Alpha Game Test1/Game Test 1/Scenes/Levels/Floor 1-2");
    }
}
