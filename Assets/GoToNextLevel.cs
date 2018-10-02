﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToNextLevel : MonoBehaviour {

    public GameObject player;
    public PersistentStats perStats;

    private void Start()
    {
        player = GameObject.Find("Player");
        perStats = GameObject.Find("PersistentStats").GetComponent<PersistentStats>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                SceneManager.LoadScene(0);
            }

            // Set initial points
            perStats.initRedPoints = player.GetComponent<stats>().pointsRed;
            perStats.initBluePoints = player.GetComponent<stats>().pointsBlue;

            // Do the animation
            //transform.parent.GetComponent<Animator>().SetBool("open", true);

            // Go to the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }

}
