using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot5 : MonoBehaviour
{
    public Transform PlayerPosition;
    //shoot setting
    public int ATK = 1;
    public float angle;
    private int counter;
    public float speed = 0.02f;
    //movement limited
    float minPosX = -8.7f;
    float maxPosX = 4.2f;
    float minPosY = -4.8f;
    float maxPosY = 4.8f;
    
    void Start()
    {
    
    }

    void Update()
    {
        counter++;
        Transform PlayerPosition = BossSpownPoint.PlayerPosi2;
        if (counter <= 240)
            angle = (Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - PlayerPosition.position.y, transform.position.x - PlayerPosition.position.x)) + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(new Vector2(0, speed));

        if (transform.position.y >= maxPosY + 1 || transform.position.y <= minPosY - 1
            || transform.position.x >= maxPosX + 1 || transform.position.x <= minPosX - 1)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCirl>().PlayerHealth -= ATK;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "PlayerBomb")
        {
            Destroy(this.gameObject);
        }
    }
}
