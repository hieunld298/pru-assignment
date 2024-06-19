using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int countEnemyInActive = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("WallBlock");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

    }

    // Update is called once per frame
    
    void Update()
    {
        GameObject[] childrenWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in childrenWithTag)
        {
            if (!obj.activeInHierarchy) 
            {
                countEnemyInActive++;
            }
        }
        if (countEnemyInActive == childrenWithTag.Length)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("WallBlock");
            
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }

}
