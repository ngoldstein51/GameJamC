﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        //sprites = new Sprite[2];
        //sprites[0] = Resources.Load<Sprite>("blueSquare");
        //sprites[1] = Resources.Load<Sprite>("redSquare");

        // Initiate fields
        playerColor = "red";

        // Get references to components
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void setColor(string color)
    {
        if (color == "blue")
        {
            //sr.sprite = sprites[0];
            
            // Update player color
            playerColor = "blue";
            // Change animator
            anim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Blue/Blue");
        }
        else
        {
            //sr.sprite = sprites[1];

            // Update player color
            playerColor = "red";
            // Change animator
            anim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Red/Red");
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