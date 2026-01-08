using UnityEngine;

public class StopMusicOnSceneLoad : MonoBehaviour
{
    private void Start()
    {
        if (PersistentAudioManager.Instance != null)
        {
            PersistentAudioManager.Instance.StopAndDestroy();
        }
    }
}