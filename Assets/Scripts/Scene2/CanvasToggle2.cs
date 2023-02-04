using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggle2 : MonoBehaviour
{

     public GameObject Canvas1;
     public GameObject Canvas2;
     public GameObject CanvasRespuestas;
     public GameObject Alumno1;
     public GameObject Alumno2;
    public GameObject Alumno3; 
     private bool isShowing1;
     private bool isShowing2 = false;
     private bool isShowing3 = false;

     public float delay = 3;
    float timer;
 
    void Start()
    {
        Invoke("ShowAnswers", 2.5f);

    }
    
     void Update() {


        isShowing2 = true;
        CanvasRespuestas.SetActive(isShowing3);

        if (Input.GetKeyDown("a") 
        || Input.GetKeyDown("w")
        || Input.GetKeyDown("s")
        || Input.GetKeyDown("d")) {
            isShowing1 = false;
            Canvas1.SetActive(isShowing1);
            isShowing2 = true;
            Canvas2.SetActive(isShowing2);
            Alumno1.SetActive(isShowing1);
            Alumno2.SetActive(isShowing1);
            Alumno3.SetActive(isShowing1);
        }


     }
    void ShowAnswers()
    {
        isShowing3 = true;
        CanvasRespuestas.SetActive(isShowing3);
    }
}
