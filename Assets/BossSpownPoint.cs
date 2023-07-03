using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpownPoint : MonoBehaviour
{   //SpownPointLocate
    public Transform Boss1;
    public Transform SP1;
    public Transform SP2;
    public Transform SP3;
    public Transform SP4;
    public Transform SP5;
    public Transform SP6;
    //PlayerLocate & EnemysOdject
    public Transform PlayerPosi;
    public static Transform PlayerPosi2;
    public Transform Enemy3Posi;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    //This class need to use
    float Enemy2LocateX = -8f;
    float Enemy2LocateY = 2f;
    float i = 2f;
    int counter = 0;
    public static int step = 0;
    public static int times = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        times = 0;
        step = 0;
        PlayerPosi2 = PlayerPosi;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosi2 = PlayerPosi;
        counter++;
        switch (step)
        {
            case 4:
                {
                    bossWave();
                }
                break;
            case 3:
                {
                    enemyWave2v2();
                }
                break;
            case 2:
                {
                    enemyWave2();
                }
                break;
            case 1:
                {
                    enemyWave1v2();
                }
                break;
            default:
                {
                    enemyWave1();
                }
                break;
        }
    }

    void enemyWave1()
    {
        if (counter % 60 == 0 && times < 5)
        {
            Instantiate(Enemy3, SP1.position, transform.rotation);
            times++;
            counter = 0;
        }
        if (counter % 120 == 0 && times >= 5 && times <= 8)
        {
            times++;
        }
        if(times > 8)
        {
            Enemy3Script.step++;
            step++;
            times = 0;
        }
    }

    void enemyWave1v2()
    {
        if (counter % 60 == 0 && times < 5)
        {
            Instantiate(Enemy3, SP6.position, transform.rotation);
            times++;
        }
        if (counter % 120 == 0 && times >= 5 && times <= 8)
        {
            times++;
        }
        if (times > 8)
        {
            step++;
            times = 0;
        }
    }

    void enemyWave2()
    {
        if (counter % 240 == 0 && times <= 5)
        {
            Enemy2LocateY += i;
            times++;
            Instantiate(Enemy2, SP2.position, transform.rotation);
            Enemy2Scipt.EnemyNewPosi = new Vector3(Enemy2LocateX, Enemy2LocateY, 0);
            Enemy2LocateX += 2f;
            i *= -1f;
        }
        if (counter % 120 == 0 && times > 5 && times <= 9)
        {
            times++;
        }
        if (times > 9)
        {
            Enemy2Scipt.leave = true;
            if (counter % 360 == 0)
            {
                step++;
                times = 0;
            }
        }
    }

    void enemyWave2v2()
    {
        if(times < 9)
        {
            Enemy2Scipt.leave = false;
        }
        if (counter % 240 == 0 && times <= 5)
        {
            Enemy2LocateY += i;
            Enemy2LocateX -= 2f;
            times++;
            Instantiate(Enemy2, SP5.position, transform.rotation);
            Enemy2Scipt.EnemyNewPosi = new Vector3(Enemy2LocateX, Enemy2LocateY, 0);
            i *= -1f;
        }
        if (counter % 120 == 0 && times > 5 && times <= 9)
        {
            times++;
        }
        if (times > 9)
        {
            Enemy2Scipt.leave = true;
            if (counter % 360 == 0)
            {
                step++;
                times = 0;
            }
        }
    }

    void bossWave()
    {
        if (counter % 360 == 0 && times < 1)
        {
            Instantiate(Enemy1, Boss1.position, transform.rotation);
            times++;
        }
    }
}
