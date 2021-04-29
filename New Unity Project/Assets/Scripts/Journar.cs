using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Journar : MonoBehaviour
{
    public static Journar Instance;

    public TMP_Text textBox;

    public GameObject textBoxImage;

    public float textFadeOutDuration = 1;

    private float countdown;
    
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

        DisableTextBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (textBoxImage.activeSelf) 
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                DisableTextBox();
            }
        }
    }

    public void Log(string text) 
    {
        //print(text);
        textBoxImage.SetActive(true);
        textBox.text = text;
        countdown = textFadeOutDuration;

    }

    private void DisableTextBox() 
    {
        textBox.text = "";

        textBoxImage.SetActive(false);
    }
}
