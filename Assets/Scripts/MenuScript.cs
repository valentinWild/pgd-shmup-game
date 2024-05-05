using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    public void StartGame(int playerNum)
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
