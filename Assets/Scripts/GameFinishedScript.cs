using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishedScript : MonoBehaviour
{

    public GameObject panel;

    void OnTriggerEnter2D (Collider2D collider) 
    {

        if (collider.tag == "Player") {
            panel.SetActive(true);
        }
    }

    void Awake()
    {
        panel.SetActive(false);
    }

    public void ExitToMenu()
    {
        // Reload the level
        Application.LoadLevel("Menu");
    }

    public void RestartGame(int playerNum)
    {
        if (playerNum == 1)
        {
            Application.LoadLevel("Stage1");
        }

        if (playerNum == 2)
        {
            Application.LoadLevel("Stage2");
        }
    }

}
