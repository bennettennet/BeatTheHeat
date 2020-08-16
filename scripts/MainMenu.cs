using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //called when "play" is clicked in main menu
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    //called when "quit" is clicked in main menu
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
