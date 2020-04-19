using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadProject : MonoBehaviour
{
    
    Color m_MouseOverColor = new Color(0.9245283f, 0.9245283f, 1f);
    private Color m_OriginalColor; //This stores the GameObject’s original color
    MeshRenderer m_Renderer;  //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    Material mat;

    public string fileName;
    public TextMeshPro displayText;
    private bool downloading;
    private UnityWebRequest uwr;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>(); //Fetch the mesh renderer component from the GameObject
        m_OriginalColor = m_Renderer.material.color; //Fetch the original color of the GameObject
    }

    void Update()
    {
        if (downloading)
        {
            displayText.text = (uwr.downloadProgress * 100).ToString("F0") + "%";
        }
    }

    void OnMouseOver()
    {
        m_Renderer.material.color = m_MouseOverColor;
    }

    void OnMouseExit()
    {
        m_Renderer.material.color = m_OriginalColor;
    }

    private void OnMouseDown()
    {
        displayText.fontSize = 35f;
        downloading = true;
        Debug.Log("Clicked Download Button");
        StartCoroutine(Download());
    }
    

    IEnumerator Download()
    {

        uwr = new UnityWebRequest("https://gimmhouse.s3.amazonaws.com/Projects/" + fileName + ".zip");
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, fileName + ".zip");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
            Debug.Log(uwr.error);
        else
        {
            downloading = false;
            Debug.Log("Download Complete! See below for file location:\n" + resultFile);
            displayText.fontSize = 15f;
            displayText.text = "Download Complete! See below for file location:\n" + resultFile;
        }
    }
}
