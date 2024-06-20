using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    private Vector3 moveInput;
    private bool isFacingRight = true;
    public Rigidbody2D rd;
    private Weapon weapon;
    public SpriteRenderer characterSR;
    public GameObject[] listEnemy;
    
    void Start()
    {
         rd = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rd.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
       
                if (((isFacingRight && moveInput.x < 0f) || (!isFacingRight && moveInput.x > 0f)))
                {
                    isFacingRight = !isFacingRight;
                    characterSR.transform.localScale = new Vector3(characterSR.transform.localScale.x * -1, characterSR.transform.localScale.y, characterSR.transform.localScale.z);
                    
                }
        Debug.Log(Weapon.instance.isTargettingEnemy(gameObject, listEnemy));

                if ( Weapon.instance.isTargettingEnemy(gameObject, listEnemy))
                {
                    GameObject objectEnemy = Weapon.instance.FindNearestObject(gameObject, listEnemy);
                    if (objectEnemy.transform.position.x < transform.position.x)
                    {
                        isFacingRight = false;
                        characterSR.transform.localScale = new Vector3(-1, 1, 1);
                    }   
                    else if (objectEnemy.transform.position.x > transform.position.x)
                    {
                        isFacingRight = true;
                        characterSR.transform.localScale = new Vector3(1, 1, 1);
                    }
                        

        }
        else
        {
            var weaponGameObject = Weapon.instance.gameObject;
            weaponGameObject.transform.rotation = Quaternion.identity;
            if (isFacingRight) weaponGameObject.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
            else if (!isFacingRight) weaponGameObject.transform.localScale = new Vector3((float)-0.5, (float)0.5, (float)0.5);
        }
            
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
         GameObject[] objects = GameObject.FindGameObjectsWithTag("TileMap");
            foreach (GameObject obj in objects)
            {
                Transform childTransform = obj.transform.Find("WallBlock");
                if (childTransform != null)
                {
                    GameObject childGameObject = childTransform.gameObject;
                    childGameObject.SetActive(true);
                }
            }
                    
        }
    }

   


}
