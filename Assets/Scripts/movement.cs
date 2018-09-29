using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private stats stats;
    public KeyCode[] controlls;
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
        controlls = keyCodes[red];
        swapTimers.Add(blue,0);
        swapTimers.Add(red, 0);
    }

    // Update is called once per frame
    void Update()
    {
        resetAnim();
        print(player.velocity.y);
        
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
        if (Input.GetKey(controlls[0]))
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            anim.SetBool("running", true);
        }
        // Left
        if (Input.GetKey(controlls[1]))
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            anim.SetBool("running", true);
        }
        // Jump
        if (Input.GetKeyDown(controlls[2]))
        {
            if (jumps >= 1)
            {
                player.velocity = new Vector3(0, 5, 0);
                jumps--;
            }
        }
        if (Input.GetKeyDown(controlls[3]))
        {
            Physics2D.gravity *= 10;
        }
        if (Input.GetKeyUp(controlls[3]))
        {
            Physics2D.gravity /= 10;
        }

        if (Input.GetKey("b"))
        {
            transform.position = new Vector2(transform.position.x, 1f);
        }

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
            controlls = keyCodes[blue];
        else
            controlls = keyCodes[red];
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
        RaycastHit2D[] hit = new RaycastHit2D[16];
        
        for (int i = 0; i < 16; i++)
        {
            float garbageCalc = (i * (((transform.localScale.x) * (playerCol.size.x)) / 16)) + (-1 * (((transform.localScale.x) * (playerCol.size.x)) / 2));

            hit[i] = Physics2D.Raycast(new Vector2(garbageCalc+transform.position.x, transform.position.y), Vector2.down, 4.1f, groundLayer);

            if (hit[i].collider)
            {
                return true;
            }
        }
        return false;
    }

}
