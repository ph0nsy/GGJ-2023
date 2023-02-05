using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JobManager : MonoBehaviour
{
    public GameObject _end;
    public GameObject _dialog;

    public GameObject _idea;
    private float start = 0;
    private int counter;
    private int[] currentPattern;
    private int[] patternSoFar;
    private string text;
    private void Start() {
        //_dialog.GetComponentInChildren<TextMeshPro>().SetText("You'll do what I tell you to do and only in the order I tell you to do; for you have no other choice.");
        _dialog.SetActive(true);
        text = generatePattern();
        _dialog.GetComponentInChildren<TextMeshPro>().SetText(text);
        counter = 0;
    }

    private void Update() {
        if(start > 7.0f)
            _dialog.SetActive(false);
        else
            start += Time.deltaTime;        
    }

    private void OnTriggerStay(Collider other) {
        _idea.SetActive(true);
        _idea.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.cyan, Mathf.PingPong(Time.deltaTime*1,1));
        if(Input.GetKeyDown(KeyCode.E)){
            if(other.gameObject.tag == "Jobs"){
                patternSoFar[counter] = other.gameObject.GetComponent<Job>()._jobCode;
                Debug.Log(counter + "===>" + patternSoFar[counter]);
                checkOrder();
                counter++;
                _idea.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        _idea.SetActive(false);
    }

    private void checkOrder(){
        Debug.Log(patternSoFar.SequenceEqual(currentPattern) ? "yes":"no");
        if (patternSoFar.SequenceEqual(currentPattern))
            displayEndings();
        else if (patternSoFar[counter] != currentPattern[counter])
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void displayEndings(){
        _end.SetActive(true);
    }

    private string generatePattern(){
        patternSoFar = new int[6];
        currentPattern = new int[6];
        currentPattern[0] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        currentPattern[1] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        currentPattern[2] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        currentPattern[3] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        currentPattern[4] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        currentPattern[5] = (int) Mathf.Floor(Random.Range(1.0f,3.9f));
        Debug.Log(string.Join(string.Empty, currentPattern));
        string bossText = string.Empty;
        for (int i = 0; i < currentPattern.Length; i++){
            if (currentPattern[i] == 1)
                bossText += " <sprite name=coffe> ";
            if (currentPattern[i] == 2)
                bossText += " <sprite name=phone> ";
            if (currentPattern[i] == 3)
                bossText += " <sprite name=doc> ";
        }
        return bossText;
    }
}
