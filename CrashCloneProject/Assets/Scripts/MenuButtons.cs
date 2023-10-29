using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Monaghan, Devin
/// 10/27/2023
/// Gives game over screen and start screen its functions
/// </summary>

public class MenuButtons : MonoBehaviour
{
    // starts game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // quits game
    public void QuitGame()
    {
        Debug.Log("Player has quit the game");
        Application.Quit();
    }
}