using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonData : MonoBehaviour
{
    const int MAX_TILES = 4;
    public int x;
    public int y;
    bool GoalFlag;
    
    // Start is called before the first frame update
    void Start()
    {
        GoalFlag = false;
        // ボタンをXとYに直す
        int i = int.Parse(this.gameObject.name.Substring(3));
        //if(i<= MAX_TILES)
        //{
        //    x = i - (MAX_TILES - 4);
        //    y = 0;
        //}
        //else if(i <= MAX_TILES*2)
        //{
        //    x = i - (MAX_TILES * 2 - 4);
        //    y = 1;
        //}
        //else if (i <= MAX_TILES*3)
        //{
        //    x = i - (MAX_TILES * 3 - 4);
        //    y = 2;
        //}
        //else if (i <= MAX_TILES*4)
        //{
        //    x = i - (MAX_TILES * 4 - 4);
        //    y = 3;
        //}
        //else if (i <= MAX_TILES*5)
        //{
        //    x = i - (MAX_TILES * 5 - 4);
        //    y = 4;
        //}

        if (i <= MAX_TILES)
        {
            x = i - (MAX_TILES - (MAX_TILES-1));
            y = 0;
        }
        else if (i <= MAX_TILES * 2)
        {
            x = i - (MAX_TILES * 2 - (MAX_TILES - 1));
            y = 1;
        }
        else if (i <= MAX_TILES * 3)
        {
            x = i - (MAX_TILES * 3 - (MAX_TILES - 1));
            y = 2;
        }
        else if (i <= MAX_TILES * 4)
        {
            x = i - (MAX_TILES * 4 - (MAX_TILES - 1));
            y = 3;
        }
        //else if (i <= MAX_TILES * 5)
        //{
        //    x = i - (MAX_TILES * 5 - (MAX_TILES - 1));
        //    y = 4;
        //}
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
    public void SetGoal(int goalX,int goalY)
    {
        if (x == goalX && y == goalY)
        {
            GoalFlag = true;
        }
    }
    public bool IsGoal()
    {
        return GoalFlag;
    }

}
