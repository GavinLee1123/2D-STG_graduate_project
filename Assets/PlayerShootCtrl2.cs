using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootCtrl2 : MonoBehaviour
{
    public float SHOOTSPEED = 0.1f;
    public int ATK = 1;
    float maxPosY = 4.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, SHOOTSPEED));
        if (transform.position.y >= maxPosY)
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
