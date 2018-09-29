using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveObject : MonoBehaviour {

    //local variables
    public string color;
    public GameObject target;
    public bool active;
    public int points;

    //game references
    public GameObject player;
    public stats stats;
    public string playerColor;

    /*
    public interactiveObject(string color,interactiveObject target, bool active, int points)
    {
        this.color = color;
        this.target = target;
        this.active = active;
        this.points = points;

        this.player = GameObject.Find("Player");
        this.stats = player.GetComponent<stats>();
        this.playerColor = stats.playerColor;
    }
    */

    protected virtual void Start()
    {
        stats = player.GetComponent<stats>();
        playerColor = stats.playerColor;
    }

    protected virtual void Update()
    {
        playerColor = stats.playerColor;
    }

    public virtual void use()
    {
        active = !active;
    }
}
