using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : interactiveObject {
    
	protected override void Start () {
        base.Start();
	}

    public override void use()
    {
        print("playerColor: " + playerColor + ", our color: " + color);
        if (playerColor == color)
        {
            base.use();
            print("actually using the real use()");
        }   
    }
}
