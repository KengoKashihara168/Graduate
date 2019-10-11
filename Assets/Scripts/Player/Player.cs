using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの番号
public enum PlayerNum
{
    Player1 = 0,
    Player2,
    Player3,
    Player4,
    MaxPlayer,
}

public class Player : MonoBehaviour
{
    private int  x; // X座標
    private int  y; // Y座標

    public PlayerNum playerNum; // プレイヤー番号

    public bool isHuman = true; // 村人フラグ

    public bool isLive; // 生存フラグ

    public bool isGoal; // ゴールフラグ


    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// 移動先の取得
    /// </summary>
    /// <param name="x">移動するX座標</param>
    /// <param name="y">移動するY座標</param>
    public void SetPosition(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// X座標の取得
    /// </summary>
    /// <returns></returns>
    public int GetX()
    {
        return x;
    }

    /// <summary>
    /// Y座標の取得
    /// </summary>
    /// <returns></returns>
    public int GetY()
    {
        return y;
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Die()
    {
        isLive = false;
    }
}
