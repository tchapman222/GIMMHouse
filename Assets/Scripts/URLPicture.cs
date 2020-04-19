using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class URLPicture : MonoBehaviour
{
    public string url;

    private float texWidth;
    private float texHeight;
    private float texSum;
    private Renderer thisRenderer;

    public enum PicType
    {
        Headshot,
        Poster
    };
    public PicType myPicType;
    // Start is called before the first frame update
    private void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        StartCoroutine(GetTex(myPicType));
    }
    
    private IEnumerator GetTex(PicType pic)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get dowloaded asset bundle
                Texture urlTexture = DownloadHandlerTexture.GetContent(uwr);
                thisRenderer.material.color = Color.white;
                thisRenderer.material.mainTexture = urlTexture;
                


                if (pic == PicType.Headshot) //Posters should be submitted at 8.5*11, but headshots may vary in size
                {
                    texWidth = urlTexture.width;
                    texHeight = urlTexture.height;
                    texSum = texHeight + texWidth;
                    gameObject.transform.localScale = new Vector3((texWidth/texSum)*.4f, 1, (texHeight/texSum)*.4f);
                }
            }
        }
    }
}
