using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveObject : MonoBehaviour {

    //local variables
    public Color color;
    public interactiveObject target;
    public bool active;
    public int points;

    //game references
    public GameObject player;
    public stats stats;
    public string playerColor;

    public interactiveObject() { }

    public interactiveObject(Color color,interactiveObject target, bool active, int points)
    {
        this.color = color;
        this.target = target;
        this.active = active;
        this.points = points;

        this.player = GameObject.Find("Player");
        this.stats = player.GetComponent<stats>();
        this.playerColor = stats.playerColor;
    }

    void Update()
    {
        playerColor = stats.playerColor;
    }

    protected virtual void use()
    {
        active = !active;
    }
}
