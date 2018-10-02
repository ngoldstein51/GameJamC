using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // Go to the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

}
