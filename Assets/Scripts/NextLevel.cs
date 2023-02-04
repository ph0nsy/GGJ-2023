using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int currentScene;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "NextLevelTrigger"){
            Debug.Log(col.gameObject);
            SceneManager.LoadScene(currentScene + 1);
        }
    }
}
