using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{

    //player color
    public string playerColor;
    //ammo
    public int ammoRed;
    public int ammoBlue;
    //health
    public int health;
    //points
    public float pointsRed;
    public float pointsBlue;

    public SpriteRenderer sr;
    public Sprite[] sprites;

    void Start()
    {
        sprites = new Sprite[2];
        sprites[0] = Resources.Load<Sprite>("blueSquare");
        sprites[1] = Resources.Load<Sprite>("redSquare");

        playerColor = "red";

        sr = GetComponent<SpriteRenderer>();
    }

    public void setColor(string color)
    {
        if (color == "blue")
        {
            sr.sprite = sprites[0];
            playerColor = "blue";
        }
        else
        {
            sr.sprite = sprites[1];
            playerColor = "red";
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
