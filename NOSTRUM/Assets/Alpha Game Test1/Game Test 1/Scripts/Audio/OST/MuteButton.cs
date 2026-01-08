using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public void Mute()
    {
        PersistentAudioManager.Instance.Mute();
    }

    public void Unmute()
    {
        PersistentAudioManager.Instance.Unmute();
    }
}