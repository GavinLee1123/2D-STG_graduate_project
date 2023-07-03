using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Text Canvas_Pause;
    bool isPause = false;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter % 120 == 0)
        {
            CheckPlayerInput();
        }
    }

    void CheckPlayerInput()
    {
        if (Input.GetKeyUp(KeyCode.P) && isPause == true)
        {
            ResumeGame();
            Debug.LogFormat("out");
        }
        if (Input.GetKeyUp(KeyCode.P) && isPause == false)
        {
            PauseGame();
            Debug.LogFormat("in");
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
        Canvas_Pause.text = "-Pause-";
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
        Canvas_Pause.text = "";
    }
}
