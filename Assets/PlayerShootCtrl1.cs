using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootCtrl1 : MonoBehaviour
{   //shoot Setting
    public float SHOOTSPEED = 15f;
    public int ATK = 1;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(new Vector2(0, SHOOTSPEED));
        if (transform.position.y >= 6) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemySript>().EnemyHealth -= ATK;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<Enemy2Scipt>().EnemyHealth -= ATK;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            collision.gameObject.GetComponent<Enemy3Script>().EnemyHealth -= ATK;
            Destroy(this.gameObject);
        }
    }
}
