using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class OpenWebsite : MonoBehaviour
{
    Color m_MouseOverColor = new Color(0.9245283f, 0.9245283f, 1f);
    private Color m_OriginalColor; //This stores the GameObject’s original color
    MeshRenderer m_Renderer;  //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    Material mat;
    
    
    public string studentURL;
    public TextMeshPro displayText;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>(); //Fetch the mesh renderer component from the GameObject
        m_OriginalColor = m_Renderer.material.color; //Fetch the original color of the GameObject
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
        Debug.Log("Clicked Download Button");
        Application.OpenURL(studentURL);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
