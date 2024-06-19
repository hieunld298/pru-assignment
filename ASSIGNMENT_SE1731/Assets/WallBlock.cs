using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    public GameObject GameObject;
    public bool IsGameObjectOnTilemap(GameObject gameObject)
    {
        Vector3 worldPosition = gameObject.transform.position;
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);

        return tile != null;
    }
    void Start()
    {
       
        bool isOnTilemap = IsGameObjectOnTilemap(GameObject);
        Debug.Log("GameObject is on Tilemap: " + isOnTilemap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
