using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus1Script : MonoBehaviour
{
    public float DropSpeed = 0.1f;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector2(0, -DropSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreText.PlayerScore += 300;
            Destroy(this.gameObject);
        }
    }
}
