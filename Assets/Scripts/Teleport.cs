using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Teleport : MonoBehaviour
{
    private Vector3 topTeleport = new Vector3(1.5f, 29, -37);
    private Vector3 bottomTeleport = new Vector3(-10, 1, -32);
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "TeleportDoorBottom")
        {
            other.gameObject.GetComponent<FirstPersonController>().enabled = false;
            other.transform.position = topTeleport;
            print(other.gameObject.name + " TeleportDoorBottom");
            StartCoroutine(EnableMovement(other));
        }
        else
        {
            other.gameObject.GetComponent<FirstPersonController>().enabled = false;
            other.transform.position = bottomTeleport;
            print(other.name + " TeleportDoorTop");
            StartCoroutine(EnableMovement(other));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnableMovement(Collider other)
    {
        yield return new WaitForSeconds(0.1f);
        other.gameObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
