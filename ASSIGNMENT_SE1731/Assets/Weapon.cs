using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public GameObject[] listEnemy;
    public static Weapon instance;
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire=0;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        RotateGun();
        
    }
    void RotateGun()
    {
         GameObject objectEnemy= FindNearestObject(player,listEnemy);
        if (objectEnemy != null)
        {
            Vector2 lookDir = objectEnemy.transform.position - player.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            {
                transform.localScale = new Vector3((float)0.5, (float)-0.5, 0);
            }
            else
            {
                transform.localScale = new Vector3((float)0.5, (float)0.5, 0);
            }
        }
        
    }

   
    public GameObject FindNearestObject(GameObject player, GameObject[] targets)
    {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject target in targets)
        {
            if (target.activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, target.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = target;
                }
            }
        }

        
        if (nearestDistance < 15)
        {
            return nearestTarget;
        }
        else
        {
            return null;
        }

    }

    public bool isTargettingEnemy(GameObject player, GameObject[] listEnemy)
    {
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject target in listEnemy)
        {
            if (target.activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, target.transform.position);
                if (distance < shortestDistance && distance < 15)
                {
                    return true;
                }
            }
        }
         return false;
       
    }

    public void Fire(bool isFacingRight)
    {
        
        timeBtwFire -= Time.deltaTime;

        if (timeBtwFire <= 0)
        {
            timeBtwFire = TimeBtwFire;
           
            if ((isFacingRight|| isTargettingEnemy(player,listEnemy)) || !isFacingRight && isTargettingEnemy(player, listEnemy)) {
                GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
                Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse) ;
            }
            else if(!isFacingRight && !isTargettingEnemy(player, listEnemy))
            {
                GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
                Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
                rb.AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
            }
        }
        
    }
    
}
