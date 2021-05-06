using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [TextArea(12,30)]

    public string noteText = "";
    public void Interact()
    {
        Journar.Instance.Log(noteText);
    }


}
