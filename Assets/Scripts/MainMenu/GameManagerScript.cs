using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public int GameStartScene;

    private void Start()
    {
        GameStartScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameStartScene+1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
