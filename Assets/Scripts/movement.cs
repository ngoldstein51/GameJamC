﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private stats stats;
    public KeyCode[] controls;
    public Dictionary<string, KeyCode[]> keyCodes = new Dictionary<string, KeyCode[]>();
    public Rigidbody2D player;
    private Animator anim;
    public LayerMask groundLayer;
    public BoxCollider2D playerCol;

    public string blue = "blue";
    public string red = "red";

    double jumps;
    float speed = 0.1f;
    public Dictionary<string,float> swapTimers = new Dictionary<string, float>();


    // Use this for initialization
    void Start ()
    {
        playerCol = GetComponent<BoxCollider2D>();
        stats = GetComponent<stats>();
        jumps = 0;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        keyCodes.Add(red, new KeyCode[] { KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow });
        keyCodes.Add(blue,new KeyCode[] { KeyCode.D, KeyCode.A, KeyCode.W, KeyCode.S });
        controls = keyCodes[red];
        swapTimers.Add(blue,0);
        swapTimers.Add(red, 0);
    }
    
    void Update()
    {
        // Reset animations every frame
        resetAnim();
        
        // Blue swap
        if (Input.GetKeyDown("q") && swapTimers[blue]<=0)
        {
            setControl(blue);
            swapTimers[blue] = 3;
        }
        // Red swap
        if (Input.GetKeyDown("space") && swapTimers[red] <= 0)
        {
            setControl(red);
            swapTimers[red] = 3;
        }
        // Right
        if (Input.GetKey(controls[0]))
        {
            // Move the character
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            // Update the animation parameter
            anim.SetBool("running", true);
            // Flip the character right
            if (transform.localScale.x < 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        // Left
        if (Input.GetKey(controls[1]))
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            anim.SetBool("running", true);
            // Flip the character right
            if (transform.localScale.x > 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        // Jump
        if (Input.GetKeyDown(controls[2]))
        {
            if (jumps >= 1)
            {
                player.velocity = new Vector3(0, 5, 0);
                jumps--;
            }
        }
        // Fast falling
        if (Input.GetKeyDown(controls[3]))
        {
            Physics2D.gravity *= 10;
        }
        // Reset fast falling
        if (Input.GetKeyUp(controls[3]))
        {
            Physics2D.gravity /= 10;
        }
        // Set player position to y = 1 for debugging
        if (Input.GetKey("b"))
        {
            transform.position = new Vector2(transform.position.x, 1f);
        }

        // Unsure what this is doing
        if (speed > 0.1f)
            speed -= 0.01f;

        if (player.velocity.y == 0)
            jumps = 2;


        anim.SetBool("grounded", isGrounded());
        anim.SetFloat("Yvelocity", player.velocity.y);
    }

    void FixedUpdate()
    {
        if (swapTimers[blue] > 0)
            swapTimers[blue] -= Time.deltaTime;
        if (swapTimers[red] > 0)
            swapTimers[red] -= Time.deltaTime;
    }

    void setControl(string color)
    {
        stats.setColor(color);
        if (color==blue)
            controls = keyCodes[blue];
        else
            controls = keyCodes[red];
    }

    public void resetAnim()
    {
        string[] states = { "grounded", "running" };
        for (int i = 0; i < states.Length; i++)
        {
            anim.SetBool(states[i], false);
        }
    }

    public bool isGrounded()
    {

        int numOfRays = 5;

        for (float i = 0; i < numOfRays; i += 0.5f)
        {
            float playerWidth = transform.localScale.x * playerCol.size.x / 2;
            float playerHeight = transform.localScale.y * playerCol.size.y / 2;

            float startX = transform.position.x - playerWidth + ((playerWidth * 2 / numOfRays) * i);

            Vector2 startVec = new Vector2(startX, transform.position.y);
            //Debug.DrawLine(startVec, new Vector2(startVec.x, startVec.y - playerHeight - 0.1f));
    
            RaycastHit2D hit = Physics2D.Raycast(startVec, Vector2.down, playerHeight + 0.1f, groundLayer);

            if (hit.collider)
            {
                return true;
            }
        }
        return false;
    }

}