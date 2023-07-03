using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public static int PlayerScore; 
    public Text Score;
    public Text PlayerHP;
    public Text Bomb;
    public Text Win;
    int counter = 0;
    void Start()
    {
        Win.text = "";
        PlayerScore = 0;
        counter = 0;
    }

    void Update()
    {
        PlayerHP.text = "Life:" + PlayerCirl.PlayerHealth2.ToString();
        Score.text = "Score:" + PlayerScore.ToString();
        Bomb.text = "Bomb:" + PlayerCirl.BombNumber2.ToString();

        if (PlayerCirl.PlayerHealth2 <= 0)
        {
            Win.text = "滿身瘡痍...";
            counter++;
            if (counter % 300 == 0)
            {
                EnemySript.EnemyLife = 2;
                BossSpownPoint.step = 0;
                BossSpownPoint.times = 0;
                SceneManager.LoadScene(3);
            }
        }
        if (EnemySript.EnemyLife < 0)
        {
            Win.text = "變異解決";
            counter++;
            if (counter % 600 == 0)
            {
                EnemySript.EnemyLife = 2;
                BossSpownPoint.step = 0;
                BossSpownPoint.times = 0;
                SceneManager.LoadScene(3);
            }
        }
    }
}
