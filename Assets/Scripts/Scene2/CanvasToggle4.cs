using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasToggle4 : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;
    private bool isShowing3 = false;
    private bool isShowing2 = true;

    public float delay = 3;
    float timer;
 
    void Start()
    {
        Invoke("HideCanvas", 2.5f);
        Invoke("ShowCanvasCarga", 2.5f);
    }
    
    void HideCanvas()
    {
        isShowing2 = false;
        Canvas1.SetActive(isShowing2);
    }
    void ShowCanvasCarga()
    {
        isShowing3 = true;
        Canvas2.SetActive(isShowing3);
    }
}
