using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    private interactiveObject obj;

    void Start()
    {
        obj = GetComponent<interactiveObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            obj.use();
        }
    }

}
