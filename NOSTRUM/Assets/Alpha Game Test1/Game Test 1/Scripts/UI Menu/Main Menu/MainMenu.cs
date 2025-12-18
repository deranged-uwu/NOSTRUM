using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("Alpha Game Test1/Game Test 1/Scenes/Levels/TutorialRoom");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
