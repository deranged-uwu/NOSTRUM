using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public GameObject Pausemenu17;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausemenu17.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        Pausemenu17.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");

    }

}
