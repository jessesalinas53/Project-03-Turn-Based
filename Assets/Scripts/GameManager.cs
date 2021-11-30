using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    private void Update()
    {
        if(player.GetComponent<Health>()._currentHealth <= 0)
        {
            Lose();
        }

        if (enemy.GetComponent<Health>()._currentHealth <= 0)
        {
            Win();
        }
    }
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
