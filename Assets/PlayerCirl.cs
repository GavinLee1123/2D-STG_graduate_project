using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCirl : MonoBehaviour
{   //Bullets Object
    public GameObject ShootSmall;
    public GameObject ShootBig;
    public GameObject SuperBomb;
    //Bullets angle setting
    Quaternion ShootRota = Quaternion.Euler(0, 0, 12);
    Quaternion ShootRota2 = Quaternion.Euler(0, 0, -12);
    //player setting
    public float PLAYERSPEED = 0.1f;
    public int PlayerHealth = 500;
    public static int PlayerHealth2;
    private int AttackSpeed = 30;
    public int BombNumber = 3;
    public static int BombNumber2;
    //movement limited
    float minPosX = -8.7f;
    float maxPosX = 4.2f;
    float minPosY = -4.8f;
    float maxPosY = 4.8f;
    //class need to use
    private int counter = 0;
    int BombRechargeTime = 0;
    bool bomb = true;

    void Start()
    {
        transform.position = new Vector3(-2.25f, transform.position.y, transform.position.z);
        BombNumber = 3;
        counter = 0;
        BombRechargeTime = 0;
        bomb = true;
        PlayerHealth2 = PlayerHealth = DifficultyCtrl.playerHP;
        BombNumber2 = BombNumber;
    }

    void Update()
    {
        PlayerHealth2 = PlayerHealth;
        BombNumber2 = BombNumber;
        counter++;
        //PlayerMove
        if (Input.GetKey(KeyCode.W) && transform.position.y <= maxPosY)
            transform.Translate(new Vector2(0, PLAYERSPEED));
        if (Input.GetKey(KeyCode.S) && transform.position.y >= minPosY)
            transform.Translate(new Vector2(0, -PLAYERSPEED));
        if (Input.GetKey(KeyCode.A) && transform.position.x >= minPosX)
            transform.Translate(new Vector2(-PLAYERSPEED, 0));
        if (Input.GetKey(KeyCode.D) && transform.position.x <= maxPosX)
            transform.Translate(new Vector2(PLAYERSPEED, 0));
        //Movement Speed Adjustment
        if (Input.GetKey(KeyCode.J))
            PLAYERSPEED = 0.01f;
        else
            PLAYERSPEED = 0.04f;
        //Attack!!!!!!
        if (counter % AttackSpeed == 0)
        {
            shoot();
        }
        //Superbomb & recharge
        if (Input.GetKey(KeyCode.K) && bomb && BombNumber > 0)
        {
            float bombAngle = 0f;
            BombNumber--;
            for (int i = 0; i < 8; i++, bombAngle += 45)
            {
                Vector2 bombPosi = transform.position + new Vector3(Mathf.Cos(bombAngle * Mathf.Deg2Rad) * 1.5f, Mathf.Sin(bombAngle * Mathf.Deg2Rad) * 1.5f);
                GameObject BombObj = Instantiate(SuperBomb, bombPosi, new Quaternion(0, 0, 0, 0));
                BombObj.GetComponent<PlayerBomb>().InitAngle = Quaternion.Euler(new Vector3(0, 0, bombAngle - 90));
            }
            bomb = false;
        }
        if (!bomb)
        {
            BombRechargeTime++;
            if (BombRechargeTime % 240 == 0)
            {
                bomb = true;
            }
        }
    }
    //Attack & Powerup
    void shoot()
    {
        if (ScoreText.PlayerScore / 200 >= 4)
        {
            Instantiate(ShootSmall, new Vector2(transform.position.x, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(ShootSmall, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(ShootSmall, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(ShootSmall, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(ShootSmall, new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(ShootBig, new Vector2(transform.position.x + 0.7f, transform.position.y + 1f), ShootRota2);
            Instantiate(ShootBig, new Vector2(transform.position.x - 0.7f, transform.position.y + 1f), ShootRota);
        }
        else
        {
            switch (ScoreText.PlayerScore / 200)
            {
                case 3:
                    {
                        Instantiate(ShootSmall, new Vector2(transform.position.x, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootBig, new Vector2(transform.position.x, transform.position.y + 1f), new Quaternion(0, 0, 0, 0));
                    }
                    break;
                case 2:
                    {
                        Instantiate(ShootSmall, new Vector2(transform.position.x, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                    }
                    break;
                case 1:
                    {
                        Instantiate(ShootSmall, new Vector2(transform.position.x, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                        Instantiate(ShootSmall, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                    }
                    break;
                default:
                    Instantiate(ShootSmall, new Vector2(transform.position.x, transform.position.y + 0.5f), new Quaternion(0, 0, 0, 0));
                    break;
            }
        }
    }
    //Death
    private void LateUpdate()
    {
        if (PlayerHealth <= 0)
            Destroy(this.gameObject);
    }
}
