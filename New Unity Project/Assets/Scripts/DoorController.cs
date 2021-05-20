using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public enum DoorState {Open,close};
    public DoorState state = DoorState.close;
    public float rotateSpeed = 10f;
    public float openAngle = 90f;

    private Vector3 originalRotation;
    private bool isMoving = false;
    
    void Start()
    {
        originalRotation = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            switch (state)
            {
                case DoorState.close:
                    if(transform.eulerAngles  != originalRotation)
                    {
                        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, originalRotation, rotateSpeed * Time.deltaTime);
                    }
                    else
                    {
                        isMoving = false;
                        state = DoorState.close;
                    }
                break;

                case DoorState.Open:
                    if (transform.eulerAngles.y != originalRotation.y + openAngle)
                    {
                        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, originalRotation + new Vector3(0, openAngle, 0), rotateSpeed * Time.deltaTime);
                    }
                    else
                    {
                        isMoving = false;
                        state = DoorState.Open;
                    }
                break;
            }
        }

    }

    public void Interact()
    {
        if (isMoving)
        {
            return;
        }  

        if(state == DoorState.close)
        {
            state = DoorState.Open;
           
        }
        else
        {
            state = DoorState.close;
        }
        isMoving = true;
    }
}
