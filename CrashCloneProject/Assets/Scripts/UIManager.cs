using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Monaghan, Devin
/// 10/27/2023
/// Manages the wumpas and lives UI display
/// </summary>

public class UIManager : MonoBehaviour
{
    public TMP_Text wumpasText;
    public TMP_Text livesText;

    // References PlayerController Script
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        wumpasText.text = "Wumpas: " + playerController.wumpaCollected.ToString();
        livesText.text = "Lives: " + playerController.lives.ToString();
    }
}