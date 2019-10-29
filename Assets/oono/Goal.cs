using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalId
{
    SEAOTTER,
    PIG,
    BIRD,
    CAT,
    FOX,
    GOAL,
    ID_NUM,
};

public class Goal : MonoBehaviour
{
    //ポジション
    private int posX;
    private int posY;
    //ゴール条件のフラグ
    public bool keyFlag;
    //ゴールが開いているかのフラグ
    public bool goalFlag;

    //ID
    public GoalId goalId;


    //ポジションの設定
    public void SetPos(int x, int y)
    {
        posX = x;
        posY = y;
    }


    //ポジションの取得/////////
    public int GetPosX()
    {
        return posX;
    }
    public int GetPosY()
    {
        return posY;
    }
    ///////////////////////////
}
