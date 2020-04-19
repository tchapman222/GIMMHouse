using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class URLVideo : MonoBehaviour
{
    
    public string videoName;
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
