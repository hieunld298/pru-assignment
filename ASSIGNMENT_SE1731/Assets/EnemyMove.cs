using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private AIPath ai;

    private EnemyHealth enemyHealth;
    void Start()
    {
        ai=gameObject.GetComponent<AIPath>();
        if (ai != null)
        {
            ai.enabled = false;
        }
        enemyHealth=gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 15)
        {
            ai.enabled = true;
        }
        else
        {
            ai.enabled = false;
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
