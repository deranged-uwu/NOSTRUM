using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public GameObject Pausemenu17;
   public GameObject SettingsOn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausemenu17.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
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
        SettingsOn.SetActive(true);
        Time.timeScale = 0;
        
        Pausemenu17.SetActive(false);
        Time.timeScale = 1;

    }

    public void GatoButton()
    {
        Pausemenu17.SetActive(true);
        Time.timeScale = 0;
        
        SettingsOn.SetActive(false);
        Time.timeScale = 1;
    }
    
}
