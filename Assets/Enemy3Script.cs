using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : MonoBehaviour
{   //shoot odject
    public GameObject Shoot;
    public GameObject Shoot4;
    //movement limited;
    public float maxPosY = 4.8f;
    //setting
    public int EnemyHealth = 3;
    public static Vector3 EnemyNewPosi = new Vector3();
    Quaternion ShootRota = Quaternion.Euler(0, 0, 180);
    public static int step = 1;
    //playerLocate
    Transform PlayerPosi;
    //use
    int counter = 120;
    float moveToY = 0.002f;
    void Start()
    {
        
    }

    void Update()
    {
        counter++;
        PlayerPosi = BossSpownPoint.PlayerPosi2;
        if (step == 1){
            transform.Translate(0.03f, moveToY, 0);
        }
        else
        {
            transform.Translate(-0.03f, moveToY, 0);
        }
        if(counter > 360)
        {
            moveToY += 0.001f;
        }
        if (counter % 120 == 0 && PlayerPosi != null)
        {
            shoot();
        }
    }
    void shoot()
    {
        GameObject ShootObj = Instantiate(Shoot, transform.position, new Quaternion(0, 0, 0, 0));
        ShootObj.GetComponent<EnemyShoot1>().InitAngle = ShootRota;
        if (counter % 240 == 0)
        {
            GameObject Shoot4Obj = Instantiate(Shoot4, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

    private void LateUpdate()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
            ScoreText.PlayerScore += 50;
        }
        if (transform.position.y >= maxPosY + 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
