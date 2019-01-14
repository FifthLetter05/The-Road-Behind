using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneManager : MonoBehaviour
{
    private int prevScene;
    private float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        prevScene = Indestructable.instance.prevScene;
        
#if UNITY_WEBGL
        OnEndReached(null);
#endif
        
        VideoPlayer videoPlayer;

        var videoGO = GameObject.Find("Video " + (prevScene == 0 ? "1" : "2"));

        videoPlayer = videoGO.GetComponent<VideoPlayer>();
        
        videoPlayer.loopPointReached += OnEndReached;
        
        videoPlayer.Play();
    }

    void OnEndReached(VideoPlayer vp)
    {
        if (prevScene == 0)
        {
            SceneManager.LoadScene("level1");
        }
        else
        {
            SceneManager.LoadScene("level2");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            OnEndReached(null);
        }
    }
}
