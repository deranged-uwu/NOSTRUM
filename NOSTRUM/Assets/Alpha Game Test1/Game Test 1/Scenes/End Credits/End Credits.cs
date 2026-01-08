using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}