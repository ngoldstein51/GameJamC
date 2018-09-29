using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : interactiveObject {

    public bool locked;
    private Animator anime;
    public bool usedPoints;
    public int points;

    protected override void Start() {
        base.Start();
        usedPoints = false;
        points = 100;
        anime = GetComponent<Animator>();
        if (color == "blue")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Blue/door_blue");
        }
        else if (color == "red")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Blue/door_red");
        }
        else if (color == "purple")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Blue/door_purple");
        }
	}

    protected override void Update ()
    {
        if (myActive)
        {
            locked = true;
        }
    }

    public override void use()
    {
        base.use();
        //changeColor();
        print("actually using the real use()");
    }

    public void changeColor(string playerColor)
    {
        
        color = playerColor;
        print("color: " + color);
        if (color == "blue")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Blue/door_blue");
        }
        else if (color == "red")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Red/door_red");
        }
        else if (color == "purple")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Purple/door_purple");
        }
            
    }
}
