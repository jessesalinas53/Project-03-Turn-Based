using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Win()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void Lose()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
