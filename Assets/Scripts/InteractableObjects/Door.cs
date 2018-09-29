using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType { teleporter, nextStage };

    // Set these in Unity UI
    public DoorType doorType; 
    public Vector2 tpDest;

    // TODO: do I need to add "override" to this
	public void use()
    {
        print(name + " is being used");
        // If the correct color player is using it
        if (playerColor == color)
        {
            if (doorType == DoorType.teleporter)
            {
                print("teleporting player to tpDest: " + tpDest);
                player.transform.position = tpDest;
            }
            else if (doorType == DoorType.nextStage)
            {
                print("moving player to next stage");
            }

            playerStats.points += points;
        }
    }
}
