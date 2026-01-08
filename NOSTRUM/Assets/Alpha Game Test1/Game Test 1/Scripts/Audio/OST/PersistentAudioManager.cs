using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PersistentAudioManager : MonoBehaviour
{
    public static PersistentAudioManager Instance;

    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        // Singleton enforcement
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void Mute()
    {
        musicSource.mute = true;
    }
    

    public void Unmute()
    {
        musicSource.mute = false;
    }

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }

    public bool IsMuted()
    {
        return musicSource.mute;
    }
    
    public void StopAndDestroy()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }

        Destroy(gameObject);
    }
}