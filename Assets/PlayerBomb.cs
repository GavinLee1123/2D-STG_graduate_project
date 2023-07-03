using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public Quaternion InitAngle;
    public int ATK = 10;
    public float speed = 0.01f;
    //movement limited
    float minPosX = -13f;
    float maxPosX = 9f;
    float minPosY = -8f;
    float maxPosY = 8f;
    //use
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = InitAngle;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter % 60 == 0)
            speed += 0.02f;
        gameObject.transform.Rotate(new Vector3(0f, 0f, 1f));
        transform.Translate(new Vector2(-speed, 0));
        if (transform.position.y >= maxPosY || transform.position.y <= minPosY 
            || transform.position.x >= maxPosX || transform.position.x <= minPosX)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemySript>().EnemyHealth -= ATK;
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<Enemy2Scipt>().EnemyHealth -= ATK;
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            collision.gameObject.GetComponent<Enemy3Script>().EnemyHealth -= ATK;
        }
    }
}
