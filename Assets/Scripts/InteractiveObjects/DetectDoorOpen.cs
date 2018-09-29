using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDoorOpen : MonoBehaviour {

    string doorColor;
    BoxCollider2D doorCol;
    door theDoor;
    stats playerStats;

    void Start()
    {
        doorColor = transform.parent.GetComponent<interactiveObject>().color;
        doorCol = transform.parent.GetComponent<BoxCollider2D>();
        theDoor = transform.parent.GetComponent<door>();
        playerStats = GameObject.FindWithTag("Player").GetComponent<stats>();
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && col.gameObject.GetComponent<stats>().playerColor == doorColor)
        {
            // Do the animation
            transform.parent.GetComponent<Animator>().SetBool("open", true);

            // "Unlock the door"
            doorCol.enabled = false;

            // Give the player their points if they haven't used this already
            if (!theDoor.usedPoints)
            {
                if (playerStats.playerColor == "red")
                {
                    print("player score changed from " + playerStats.pointsRed);
                    playerStats.pointsRed += theDoor.points;
                    print("to " + playerStats.pointsRed);
                }
                else
                {
                    print("player score changed from " + playerStats.pointsBlue);
                    playerStats.pointsBlue += theDoor.points;
                    print("to " + playerStats.pointsBlue);
                }
                theDoor.usedPoints = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // Do the animation
            transform.parent.GetComponent<Animator>().SetBool("open", false);

            // "Relock" the door
            doorCol.enabled = true;
        }
    }

}
