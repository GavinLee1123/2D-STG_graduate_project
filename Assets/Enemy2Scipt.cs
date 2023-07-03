using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Scipt : MonoBehaviour
{   //shoot odject
    public GameObject Shoot;
    public GameObject Shoot4;
    //setting
    public static bool leave = false;
    public int EnemyHealth = 10;
    public static Vector3 EnemyNewPosi = new Vector3();
    Quaternion ShootRota = Quaternion.Euler(0, 0, 155);
    Quaternion ShootRota2 = Quaternion.Euler(0, 0, 205);
    //playerLocate
    Transform PlayerPosi;
    //movementlimited
    public float maxPosY = 4.8f;
    //use
    int counter = 0;
    int move = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(move < 240)
        {
            transform.Translate((EnemyNewPosi.x - transform.position.x) / 120, (EnemyNewPosi.y - transform.position.y) / 120, 0);
            move++;
        }
        if(leave == true)
        {
            transform.Translate(0, (8f - transform.position.y) / 120, 0);
        }
        PlayerPosi = BossSpownPoint.PlayerPosi2;
        if (PlayerPosi != null)
        {
            shoot();
        }
    }
    void shoot()
    {
        if (counter % 200 == 0)
        {
            GameObject ShootObj = Instantiate(Shoot, transform.position, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = ShootRota;
            ShootObj = Instantiate(Shoot, transform.position, new Quaternion(0, 0, 0, 0));
            ShootObj.GetComponent<EnemyShoot1>().InitAngle = ShootRota2;
            GameObject Shoot4Obj = Instantiate(Shoot4, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
    private void LateUpdate()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
            ScoreText.PlayerScore += 100;
        }
        if (transform.position.y >= maxPosY + 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
