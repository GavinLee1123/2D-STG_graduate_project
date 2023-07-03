using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyCtrl : MonoBehaviour
{
    public static int playerHP; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hardClick()
    {
        playerHP = 1;
        SceneManager.LoadScene(2);
    }

    public void middenClick()
    {
        playerHP = 5;
        SceneManager.LoadScene(2);
    }

    public void easyClick()
    {
        playerHP = 10;
        SceneManager.LoadScene(2);
    }
}
