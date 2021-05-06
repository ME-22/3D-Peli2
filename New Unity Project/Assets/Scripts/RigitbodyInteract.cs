using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitbodyInteract : MonoBehaviour, IInteractable
{
    public float pushForce = 10;
    Rigidbody rigidbody;

    public void Interact()
    {
        rigidbody.AddForce(Camera.main.transform.forward * pushForce, ForceMode.Impulse);
    }
 
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

}
