using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ChangeScene(string buttonVal)
    {
        if (buttonVal == "Start")
        {
            SceneManager.LoadScene(1);
        }
        else if (buttonVal == "Quit")
        {
            Application.Quit();
        }
    }
}