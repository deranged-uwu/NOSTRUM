using UnityEngine;

public class TempMute : MonoBehaviour
{
    [SerializeField] private AudioSource targetAudioSource;

    // Call this from the "Mute" button
    public void MuteAudio()
    {
        if (targetAudioSource != null)
        {
            targetAudioSource.mute = true;
        }
    }

    // Call this from the "Unmute" button
    public void UnmuteAudio()
    {
        if (targetAudioSource != null)
        {
            targetAudioSource.mute = false;
        }
    }
}
