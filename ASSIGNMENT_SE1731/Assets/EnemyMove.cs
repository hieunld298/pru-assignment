
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
   

    private EnemyHealth enemyHealth;
    void Start()
    {
       
        enemyHealth=gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 15)
        {
            Debug.Log("Moveeeeee");
        }
        else
        {
            Debug.Log("NOT Moveeeeee");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyHealth.TakeDamage(1);
        }
    }

}
