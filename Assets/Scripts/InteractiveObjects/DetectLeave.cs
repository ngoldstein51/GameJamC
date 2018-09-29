using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLeave : MonoBehaviour {

    private interactiveObject obj;

    void Start()
    {
        obj = GetComponent<interactiveObject>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // if we are a pressure plate
        if (obj.tag == "plate" && col.tag == "Player")
        {
            ((pressurePlate)obj).steppedOn = false;
        }
    }

}
