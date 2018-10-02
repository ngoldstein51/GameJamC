using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    private interactiveObject obj;
    private SpriteRenderer sr;

    void Start()
    {
        obj = GetComponent<interactiveObject>();
        sr = GetComponent<SpriteRenderer>();
       // player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("we're getting pressed down");
        // if we are a pressure plate
        if (obj.tag == "plate")
        {
            ((pressurePlate)obj).steppedOn = col.tag == "Player";
            // Red
            if (gameObject.layer == 9)
            {
                sr.sprite = Resources.Load<Sprite>("Objects/switch_red_pressed");
            }
            // Blue
            else if (gameObject.layer == 10)
            {
                sr.sprite = Resources.Load<Sprite>("Objects/switch_Blue_pressed");
            }
                
        }
    }

}
