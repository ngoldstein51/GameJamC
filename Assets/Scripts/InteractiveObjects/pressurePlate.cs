using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : interactiveObject {

    public bool steppedOn;

	protected override void Start () {
        base.Start();
        steppedOn = false;
	}

    protected override void Update()
    {
        base.Update();
        if (steppedOn)
        {
            myActive = playerColor == color;
        }
        else
        {
            myActive = false;
        }

        target.GetComponent<interactiveObject>().myActive = myActive;

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
