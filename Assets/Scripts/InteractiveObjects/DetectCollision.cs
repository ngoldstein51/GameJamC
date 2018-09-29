using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    private interactiveObject obj;
    //private GameObject player;

    void Start()
    {
        obj = GetComponent<interactiveObject>();
       // player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("we're getting pressed down");
        // if we are a pressure plate
        if (obj.tag == "plate")
        {
            ((pressurePlate)obj).steppedOn = col.tag == "Player";
        }
    }

}
