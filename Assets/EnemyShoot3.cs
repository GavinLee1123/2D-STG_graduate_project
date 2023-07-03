using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot3 : MonoBehaviour
{
    public Quaternion InitAngle;
    public int ATK = 1;
    private int times = 0;
    public float speed = 0.02f;
    float minPosX = -8.7f;
    float maxPosX = 4.2f;
    float minPosY = -4.8f;
    float maxPosY = 4.8f;
    
    void Start()
    {
        transform.rotation = InitAngle;
    }

    void Update()
    {
        transform.Translate(new Vector2(0, speed));
        if ((transform.position.y >= maxPosY || transform.position.y <= minPosY) && times < 2)
        {
           transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 - transform.rotation.eulerAngles.z));
           times++;
        }
        if ((transform.position.x >= maxPosX || transform.position.x <= minPosX) && times < 2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -transform.rotation.eulerAngles.z));
            times++;
        }
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
