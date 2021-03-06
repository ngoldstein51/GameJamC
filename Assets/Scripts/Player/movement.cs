﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    //local variables
    public KeyCode[] controls;
    public Dictionary<string, KeyCode[]> keyCodes = new Dictionary<string, KeyCode[]>();
    public string blue = "blue";
    public string red = "red";
    double jumps;
    public float speed;
    public float swapTimer;

    //game references
    private stats stats;
    public Rigidbody2D player;
    private Animator anim;
    public LayerMask groundLayer, redLayer, blueLayer;
    public BoxCollider2D playerCol;
    public PersistentStats perStats;

    // Use this for initialization
    void Start ()
    {
        playerCol = GetComponent<BoxCollider2D>();
        stats = GetComponent<stats>();
        jumps = 0;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 0.05f;

        keyCodes.Add(red, new KeyCode[] { KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow });
        keyCodes.Add(blue,new KeyCode[] { KeyCode.D, KeyCode.A, KeyCode.W, KeyCode.S });
        controls = keyCodes[red];
        swapTimer = 3.0f;
    }
    
    void Update()
    {
        // Reset animations every frame
        resetAnim();
        
        // Go to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        // Reset level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            stats.pointsRed = perStats.initRedPoints;
            stats.pointsBlue = perStats.initBluePoints;
        }

        // Blue swap
        if (Input.GetKeyDown("q") && swapTimer<=0)
        {
            if (stats.playerColor == red)
            {
                setControl(blue);
                swapTimer = 3;
            }
        }
        // Red swap
        if (Input.GetKeyDown(KeyCode.RightControl) && swapTimer <= 0)
        {
            if (stats.playerColor == blue)
            {
                setControl(red);
                swapTimer = 3;
            }
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
                player.velocity = new Vector3(0, 9, 0);
                jumps--;
            }
        }

        if (player.velocity.y == 0)
            jumps = 2;
        
        anim.SetBool("grounded", isGrounded());
        anim.SetFloat("Yvelocity", player.velocity.y);
    }

    void FixedUpdate()
    {
        if (swapTimer > 0)
            swapTimer -= Time.deltaTime;
    }

    public void setControl(string color)
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

            Vector2 startVec = new Vector2(startX, transform.position.y - playerHeight - 0.1f);
            //Debug.DrawLine(startVec, new Vector2(startVec.x, startVec.y - playerHeight - 0.1f));
    
            RaycastHit2D hitGround = Physics2D.Raycast(startVec, Vector2.down, 0.1f, groundLayer);
            RaycastHit2D hitRed = Physics2D.Raycast(startVec, Vector2.down, 0.1f, redLayer);
            RaycastHit2D hitBlue = Physics2D.Raycast(startVec, Vector2.down, 0.1f, blueLayer);

            if (hitGround.collider || hitRed.collider || hitBlue.collider)
            {
                return true;
            }
        }
        return false;
    }

}
