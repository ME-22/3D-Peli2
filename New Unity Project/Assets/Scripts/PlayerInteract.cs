using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range = 2;
    Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ProcessRaycast();
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(FPSCamera.transform.position,FPSCamera.transform.forward, out hit, range))
        {
            if(hit.collider.gameObject.GetComponent<IInteractable>() != null)
            {
                hit.collider.gameObject.GetComponent<IInteractable>()?.Interact();
            }
        }
    }
}
