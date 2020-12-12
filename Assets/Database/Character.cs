﻿using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public string c_name = "Template";
    public float hat_R = -1;
    public float hat_G = -1;
    public float hat_B = -1;
    
    public Boolean gender;

    
    public float music = 0.5f;
    public float sound = 0.5f;
    
    private GameObject desatHat_0;
    private GameObject desatHat_4;


    public Animator ani;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen") return;
        desatHat_0 = GameObject.Find("desatHat_0");
        desatHat_4 = GameObject.Find("desatHat_4");

        CharacterData l = saveLoad.LoadData();
        if (l != null)
        {
            
            hat_R = l.hat_R;
            hat_B = l.hat_B;
            hat_G = l.hat_G;

            gender = l.gender;
            
            if (SceneManager.GetActiveScene().name == "CreateCharacter")
            {
                hat_R = 0.5f;
                hat_B = 0.5f;
                hat_G = 0.5f;

                gender = true;
            }
            
            music = l.music;
            sound = l.sound;
            
            c_name = l.name;

            
            
            var animator = GetComponent<Animator>();
            
            animator.SetBool("gender",gender);
            
            
            desatHat_0.GetComponent<SpriteRenderer>().material.color = new Color(hat_R,hat_G,hat_B);
            desatHat_4.GetComponent<SpriteRenderer>().material.color = new Color(hat_R,hat_G,hat_B);
        }
    }

    private void Update()
    {
        
    }
    
    public void c_gender(Boolean g)
    {
        gender = g;
    }
    public void c_b(float b)
    {
        hat_B = b;
    }
    public void c_r(float r)
    {
        hat_R = r;
    }
    public void c_g(float g)
    {
        hat_G = g;
    }
    public void c_n (string n)
    {
        c_name = n;
    }
    public void c_sound(float s)
    {
        sound = s;
    }
    public void c_music(float m)
    {
        music = m;
    }
    public void saveC()
    {
        saveLoad.SaveData(this); 
    }
}