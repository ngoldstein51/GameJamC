using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : interactiveObject {

    public bool steppedOn;
    public bool usedPoints;
    public int platePoints;

	protected override void Start () {
        base.Start();
        steppedOn = false;
        platePoints = 100;
        usedPoints = false;
	}

    protected override void Update()
    {
        base.Update();
        
        if (steppedOn)
        {
            myActive = playerColor == color;
            target.GetComponent<door>().changeColor(playerColor);
            if (!usedPoints)
            {
                if (playerColor == "red")
                {
                    player.GetComponent<stats>().pointsRed += platePoints;
                }
                else if (playerColor == "blue")
                {
                    player.GetComponent<stats>().pointsBlue += platePoints;
                }
                usedPoints = true;
            }
        }
        else
        {
            myActive = false;
        }

        //target.GetComponent<interactiveObject>().myActive = myActive;

    }

    public override void use()
    {
        print("playerColor: " + playerColor + ", our color: " + color);
        if (playerColor == color)
        {
            base.use();
            print("actually using the real use()");
            target.GetComponent<interactiveObject>().use();
        }   
    }
}
