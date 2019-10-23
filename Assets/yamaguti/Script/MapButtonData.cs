using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonData : MonoBehaviour
{
    const int MAX_TILES = 5;
    public int x;
    public int y;
    
    // Start is called before the first frame update
    void Start()
    {
        // ボタンをXとYに直す
        int i = int.Parse(this.gameObject.name.Substring(3));
        Debug.Log(i);
        if(i<= MAX_TILES)
        {
            x = i - (MAX_TILES - 4);
            y = 0;
        }
        else if(i <= MAX_TILES*2)
        {
            x = i - (MAX_TILES * 2 - 4);
            y = 1;
        }
        else if (i <= MAX_TILES*3)
        {
            x = i - (MAX_TILES * 3 - 4);
            y = 2;
        }
        else if (i <= MAX_TILES*4)
        {
            x = i - (MAX_TILES * 4 - 4);
            y = 3;
        }
        else if (i <= MAX_TILES*5)
        {
            x = i - (MAX_TILES * 5 - 4);
            y = 4;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPosX()
    {
        return x;
    }
    public int GetPosY()
    {
        return y;
    }
}
