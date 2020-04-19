using System;
using System.Collections;
using System.Collections.Generic;
using UnitySampleAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.Video;

//Manages the changing of colors when hovering over something (like the door handle)
//Pretty hacky way of doing it. I found certain values produced odd emmissions and colors
//so I took advantage of it.

public class OnMouseOverColor : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)

    Color m_MouseOverColor = new Color(0.9245283f, 0.9245283f, 1f);


    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;
    Material mat;
    public VideoPlayer myVideo;
    public GameObject headShot;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        mat = m_Renderer.material;
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
        
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
        myVideo.Play();
        gameObject.SetActive(false);
        headShot.SetActive(false);
    }
}
