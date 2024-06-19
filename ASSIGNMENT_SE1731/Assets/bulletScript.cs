using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallBlock" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BlockBullet")
        {
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlockBullet")
        {
            Destroy(gameObject);
        }
    }

}
