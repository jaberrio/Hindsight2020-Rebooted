using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignOpen : MonoBehaviour, Interactable
{   
    public GameObject message;
    public String messageToDisplay;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        
        message.GetComponentInChildren<Text>().text = messageToDisplay;
        message.GetComponentInChildren<Text>().enabled = true;
        message.GetComponent<Image>().enabled = true;
        
    }
}
