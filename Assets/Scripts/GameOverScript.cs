using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{

    public Transform player;

    /* public TextMeshPro healthText; */
    /* private HealthScript playerHealth; */
    private Button[] buttons;

    void Awake()
    {
        /* // Get the player health script
        playerHealth = player.gameObject.GetComponent<HealthScript>();
 */
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
        HideButtons();
    }

    void Update() {
       /* healthText.SetText("Health: " + playerHealth.hp.ToString()); */
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
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
