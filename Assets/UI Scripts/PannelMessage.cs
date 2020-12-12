using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PannelMessage : MonoBehaviour
{
    private float clearDelta;
    
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(String text, int time)
    {
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
        
    }
}
