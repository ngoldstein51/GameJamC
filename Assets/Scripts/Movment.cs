using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {

    public Rigidbody2D player;
    public BoxCollider2D playerCol;
    double jumps;
    float speed = 0.1f;

    // Use this for initialization
    void Start ()
    {
        jumps = 0;
        player = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
        if (Input.GetKey("left"))
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        if (Input.GetKeyDown("up"))
        {
            if (jumps >= 1)
            {
                player.velocity = new Vector3(0, 5, 0);
                jumps--;
            }
        }
        if (Input.GetKey("down"))
        {
            if(player.velocity.y!=0)
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
        }

        if (Input.GetKey("b"))
        {
            transform.position = new Vector2(transform.position.x, 1f);
        }

        if (speed > 0.1f)
            speed -= 0.01f;

        if (player.velocity.y == 0)
            jumps = 2;
    }
}
