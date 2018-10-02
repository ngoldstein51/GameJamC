using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLeave : MonoBehaviour {

    private interactiveObject obj;
    private SpriteRenderer sr;

    void Start()
    {
        obj = GetComponent<interactiveObject>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // if we are a pressure plate
        if (obj.tag == "plate" && col.tag == "Player")
        {
            ((pressurePlate)obj).steppedOn = false;
            if (gameObject.layer == 9)
            {
                sr.sprite = Resources.Load<Sprite>("Objects/switch_red_unpressed");
            }
            else if (gameObject.layer == 10)
            {
                sr.sprite = Resources.Load<Sprite>("Objects/switch_Blue_unpressed");
            }
                
        }
    }

}
