using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsLoader : MonoBehaviour
{
    public void LoadBad(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadGood(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }
}
