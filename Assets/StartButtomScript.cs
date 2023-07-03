using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
