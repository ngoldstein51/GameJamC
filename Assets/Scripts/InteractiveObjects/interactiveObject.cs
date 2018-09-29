using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveObject : MonoBehaviour {

    //local variables
    public string color;
    public GameObject target;
    public bool myActive;
    //public int points;

    //game references
    public GameObject player;
    public stats stats;
    public string playerColor;

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
        myActive = !myActive;
    }
}
