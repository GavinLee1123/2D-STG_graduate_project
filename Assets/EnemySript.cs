using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySript : MonoBehaviour
{   //Shoot Object
    public GameObject Shoot;
    public GameObject Shoot2;
    public GameObject Shoot3;
    public GameObject Shoot4;
    public GameObject Shoot5;
    public GameObject Bonus;
    //player & enemy locate
    Transform PlayerPosi;
    //Enemt setting
    public int EnemyHealth = 200;
    public static int EnemyLife = 2;
    //movement limited
    public float minPosX = -8.7f;
    public float maxPosX = 4.2f;
    public float minPosY = -4.8f;
    public float maxPosY = 4.8f;

    int counter = 0;
    Vector3 EnemyNewPosi = new Vector3();
    int Danmaku3Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 200;
        EnemyLife = 2;
        counter = 0;
        PlayerPosi = BossSpownPoint.PlayerPosi2;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        PlayerPosi = BossSpownPoint.PlayerPosi2;
        if (EnemyLife == 0)
        {
            movemode3();
        }
        if(EnemyLife == 1)
        {
            movemode2();
        }
        if (EnemyLife == 2)
        {
            movemode1();
        }
        if(PlayerPosi != null)
        {
            if (EnemyLife == 0)
            {
                shootOut3();
            }
            if (EnemyLife == 1)
            {
                shootOut2();
            }
            if (EnemyLife == 2)
            {
                shootOut();
            }
        }
    }
    private void LateUpdate()
    {
        if (EnemyHealth <= 0 && EnemyLife > 0)
        {
            ScoreText.PlayerScore += 1000;
            EnemyLife--;
            EnemyHealth += (3 - EnemyLife) * 200;
        }
        if (EnemyHealth <= 0 && EnemyLife == 0)
        {
            Destroy(this.gameObject);
            ScoreText.PlayerScore += 10000;
            EnemyLife--;
            GameObject Bouns = Instantiate(Bonus, transform.position, transform.rotation);
        }
    }

    //Movement Mode-------------------------------------------------
    void movemode1()
    {
        if (counter % 240 == 0)
            EnemyNewPosi = new Vector3(Random.Range(minPosX + 1, maxPosX - 1), Random.Range(2.5f, 4f), 0);
        if (counter >= 120)
            transform.Translate((EnemyNewPosi.x - transform.position.x) / 120, (EnemyNewPosi.y - transform.position.y) / 120, 0);
    }
    void movemode2()
    {
        if (counter % 120 == 0)
            EnemyNewPosi = new Vector3(Random.Range(minPosX + 1, maxPosX - 1), Random.Range(2.5f, 4f), 0);
        if (counter >= 120)
            transform.Translate((EnemyNewPosi.x - transform.position.x) / 120, (EnemyNewPosi.y - transform.position.y) / 120, 0);
    }
    void movemode3()
    {
        EnemyNewPosi = new Vector3(-2.25f, 4f, 0);
        transform.Translate((EnemyNewPosi.x - transform.position.x) / 10, (EnemyNewPosi.y - transform.position.y) / 10, 0);
    }
    //Attack Mode----------------------------------------------
    void shootOut()
    {
        if (counter % 480 == 0)
        {
            danmaku2();
        }
        if (counter % 120 == 0)
        {
            if(Danmaku3Count == 0)
            {
                danmaku3();
                Danmaku3Count++;
            }
            else
            {
                danmaku3v2();
                Danmaku3Count--;
            }
        }
    }

    void shootOut2()
    {
        if (counter % 120 == 0)
        {
            danmaku1();
        }
        if(counter % 10 == 0)
        {
            GameObject ShootObj = Instantiate(Shoot, transform.position, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        }

    }

    void shootOut3()
    {
        if(counter % 50 == 0)
        {
            danmaku4();
        }
        if (counter % 240 == 0)
        {
            GameObject Shoot5Obj = Instantiate(Shoot5, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
    //Danmaku Design---------------------------------------------
    void danmaku1()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject ShootObj = Instantiate(Shoot, transform.position, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = Quaternion.Euler(new Vector3(0, 0, i * 12));
        }
    }
    void danmaku2()
    {
        Vector2 Locate = new Vector2(transform.position.x + 0.3f, transform.position.y);
        Vector2 Locate2 = new Vector2(transform.position.x - 0.3f, transform.position.y);
        for (int i = 0; i < 10; i++)
        {
            GameObject Shoot4Obj = Instantiate(Shoot4, Locate, transform.rotation);
            Shoot4Obj.GetComponent<EnemyShoot4>().speed = 0.02f + 0.005f * i;
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject Shoot4Obj = Instantiate(Shoot4, Locate2, transform.rotation);
            Shoot4Obj.GetComponent<EnemyShoot4>().speed = 0.02f + 0.005f * i;
        }
    }
    void danmaku3()
    {
        float shootAngle = 0f;
        for (int i = 0; i < 30; i++, shootAngle += 12)
        {
            Vector2 shootPosi = transform.position + new Vector3(Mathf.Cos(shootAngle * Mathf.Deg2Rad) * 1, Mathf.Sin(shootAngle * Mathf.Deg2Rad) * 1);
            GameObject ShootObj = Instantiate(Shoot, shootPosi, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = Quaternion.Euler(new Vector3(0, 0, shootAngle - 30)); 
        }
            
    }
    void danmaku3v2()
    {
        float shootAngle = 0f;
        for (int i = 0; i < 30; i++, shootAngle += 12)
        {
            Vector2 shootPosi = transform.position + new Vector3(Mathf.Cos(shootAngle * Mathf.Deg2Rad) * 1, Mathf.Sin(shootAngle * Mathf.Deg2Rad) * 1);
            GameObject ShootObj = Instantiate(Shoot, shootPosi, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = Quaternion.Euler(new Vector3(0, 0, shootAngle - 150));
        }
    }
    void danmaku4()
    {
        GameObject Shoot2Obj = Instantiate(Shoot2, transform.position, new Quaternion(0, 0, 0, 0));
        Shoot2Obj.GetComponent<EnemyShoot2>().InitAngle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        GameObject Shoot3Obj = Instantiate(Shoot3, transform.position, new Quaternion(0, 0, 0, 0));
        Shoot3Obj.GetComponent<EnemyShoot3>().InitAngle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
    }
}