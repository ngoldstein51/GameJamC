using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveObject : MonoBehaviour {
    public Color color;
    public interactiveObject target;
    public bool active;

    public interactiveObject(Color color,interactiveObject target, bool active)
    {
        this.color = color;
        this.target = target;
        this.active = active;
    }

    void use()
    {
        active = !active;
    }
}
