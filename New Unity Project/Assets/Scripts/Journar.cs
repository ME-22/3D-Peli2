using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Journar : MonoBehaviour
{
    public static Journar Instance;

    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
