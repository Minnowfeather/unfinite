using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class generateWalls : MonoBehaviour
{
    public Tile horizontalTop_top, horizontalTop_mid, horizontalTop_bot;
    public Tile horizontalBottom_tile;
    public Tilemap map;
    public void horizontalTop(int length, Vector3Int pos){
        for(int i = 0; i < length; i++){
            map.SetTile(new Vector3Int(pos.x + i, pos.y, pos.z), horizontalTop_top);
        }
        for(int i = 0; i < length; i++){
            map.SetTile(new Vector3Int(pos.x + i, pos.y-1, pos.z), horizontalTop_mid);
        }
        for(int i = 0; i < length; i++){
            map.SetTile(new Vector3Int(pos.x + i, pos.y-2, pos.z), horizontalTop_bot);
        }
    }
    public void horizontalBottom(int length, Vector3Int pos){
        for(int i = 0; i < length; i++){
            map.SetTile(new Vector3Int(pos.x + i, pos.y, pos.z), horizontalBottom_tile);
        }
    }

    void Update(){
        if(Input.GetKey("[5]")){
            horizontalBottom(5, new Vector3Int(20,0,0));
            print("done");
        }
    }
    
}
