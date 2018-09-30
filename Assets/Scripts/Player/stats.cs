using System;﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{

    public string playerColor;
    public int ammoRed;
    public int ammoBlue;
    public int health;
    public float pointsRed;
    public float pointsBlue;

    public SpriteRenderer sr;
    public Sprite[] sprites;
    public Animator anim;
    public Text red_num;
    public Text blue_num;
    public Text timerSec;
    public Text timerMili;
    public float bomb;
    
    void Update()
    {
        red_num.text = pointsRed.ToString();
        blue_num.text = pointsBlue.ToString();

    }

    void FixedUpdate()
    {
        bomb -= Time.deltaTime;
        timerSec.text = string.Format("{0:00}",bomb);
        timerMili.text = Math.Truncate((bomb-(int)bomb)*100).ToString();
    }

    void Start()
    {
        Application.targetFrameRate=60;

        // Initiate fields
        playerColor = "red";

        // Get references to components
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        bomb = 11;
    }

    public void setColor(string color)
    {
        if (color == "blue")
        {
            // Update player color
            playerColor = "blue";
            // Change animator
            anim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Player/Blue/Blue");
            // Change layer to blue
            gameObject.layer = 10;
        }
        else
        {
            // Update player color
            playerColor = "red";
            // Change animator
            anim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Player/Red/Red");
            // Change layer to blue
            gameObject.layer = 9;
        }
    }

    public void updateRedAmmo(int delta)
    {
        ammoRed += delta;
    }

    public void updateBlueAmmo(int delta)
    {
        ammoBlue += delta;
    }

    public void updateHealth(int delta)
    {
        health += delta;
    }

    public void updateRedPoints(int delta)
    {
        pointsRed += delta;
    }

    public void updateBluePoints(int delta)
    {
        pointsBlue += delta;
    }
}
