using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    int current;
    //float timer = 3.0f;
    public float delay = 3;
    float timer;
    void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex;
        Invoke("ChangeScene1", 2.5f);

    }

    void ChangeScene1()
    {
        SceneManager.LoadScene(current + 1);
    }

    //void Update()
    //{
    //    float tick = Time.deltaTime;
    //    if (Time.deltaTime - tick < timer)
    //    {
    //        SceneManager.LoadScene(current + 1);
    //    }
    //}
}
