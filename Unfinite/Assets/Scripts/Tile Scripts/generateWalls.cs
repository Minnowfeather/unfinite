using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class generateWalls : MonoBehaviour
{
    public Tile horizontalTop_top, horizontalTop_mid, horizontalTop_bot;
    public Tile horizontalBottom_tile;
    public Tile vertical_left, vertical_right;
    public Tile corner_NW, corner_NE, corner_SW, corner_SE;
    public Tile defaultSand;
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

    public void verticalLeft(int length, Vector3Int pos, bool addCorners){
        if(!addCorners){
            for(int i = 0; i < length; i++){
                map.SetTile(new Vector3Int(pos.x, pos.y - i, pos.z), vertical_left);
            }
        } else{
            map.SetTile(pos, corner_NW);
            map.SetTile(new Vector3Int(pos.x, pos.y - (length-1), pos.z), corner_SW);
            for(int i = 1; i < length-1; i++){
                map.SetTile(new Vector3Int(pos.x, pos.y - i, pos.z), vertical_left);
            }
        }
    }

    public void verticalRight(int length, Vector3Int pos, bool addCorners){
        if(!addCorners){
            for(int i = 0; i < length; i++){
                map.SetTile(new Vector3Int(pos.x, pos.y - i, pos.z), vertical_right);
            }
        } else{
            map.SetTile(pos, corner_NE);
            map.SetTile(new Vector3Int(pos.x, pos.y - (length-1), pos.z), corner_SE);
            for(int i = 1; i < length-1; i++){
                map.SetTile(new Vector3Int(pos.x, pos.y - i, pos.z), vertical_right);
            }
        }
    }

    public void fillDefaultSand(int width, int height, Vector3Int pos){
        for(int i = 0; i < width; i++){
            for(int j = 0; j < height; j++){
                map.SetTile(new Vector3Int(pos.x + i, pos.y - j, pos.z), defaultSand);
            }
        }
    }

    public void box(int width, int height, Vector3Int pos){
        horizontalTop(width-1, new Vector3Int(pos.x + 1, pos.y, pos.z));
        horizontalBottom(width-1, new Vector3Int(pos.x + 1, pos.y - (height-1), pos.z));
        verticalRight(height, new Vector3Int(pos.x + width - 1, pos.y, pos.z), true);
        verticalLeft(height, pos, true);
        fillDefaultSand(width - 2, height - 4, new Vector3Int(pos.x + 1, pos.y - 3, pos.z));
    }

    void Update(){
        if(Input.GetKey("[5]")){
            box(10, 10, new Vector3Int(20,0,0));
        }
    }
    
}
