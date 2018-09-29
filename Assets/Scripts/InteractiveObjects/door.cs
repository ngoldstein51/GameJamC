using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : interactiveObject {

    public bool locked;
    private Animator anime;
    public bool usedPoints;
    public int points;

	protected override void Start () {
        base.Start();
        usedPoints = false;
        points = 100;
        anime = GetComponent<Animator>();
        print("color: " + color);
        if (color == "blue")
        {
            anime.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/Door/Blue/door_blue");
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
        if (playerColor == color)
        {
            base.use();
            print("actually using the real use()");
        }   
    }
}
