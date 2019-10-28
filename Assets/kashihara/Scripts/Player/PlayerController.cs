using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    private  static Player[]         players; // プレイヤーたち
    private  static int              TurnCount{ get; set; }

    /// <summary>
    /// インスタンス
    /// </summary>
    public static PlayerController Instance
    {
        get
        {
            instance = FindObjectOfType<PlayerController>();

            if (instance == null)
            {
                GameObject obj = new GameObject("PlayerController");
                instance = obj.AddComponent<PlayerController>();
                DontDestroyOnLoad(instance);
                PlayerInitialize();
            }
            return instance;
        }

        set { }
    }

    private static void PlayerInitialize()
    {
        players = new Player[(int)PlayerNum.MaxPlayer];
        GameObject obj = new GameObject("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = obj.AddComponent<Player>();

            // 各プレイヤーの初期化
            players[i].SetPosition(0, 0);
            players[i].playerNum = (PlayerNum)i;
            players[i].isHuman = true;
            players[i].isLive = true;
            players[i].isGoal = false;
        }
    }

    /// <summary>
    /// 指定プレイヤーを人狼に設定
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <param name="flag">村人フラグ</param>
    public void SetWolf(int num)
    {
        players[num].isHuman = false;
    }
    /// <summary>
    /// 指定プレイヤーが村人か伝える
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>村人フラグ</returns>
    public bool IsHuman(int num)
    {
        return players[num].isHuman;
    }

    /// <summary>
    /// 指定プレイヤーの移動
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    public void SetPosition(int num, int x, int y)
    {
        players[num].SetPosition(x, y);
    }
    /// <summary>
    /// 指定プレイヤーのX座標を伝える
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>X座標</returns>
    public int GetPlayerPositionX(int num)
    {
        return players[num].GetX();
    }
    /// <summary>
    /// 指定プレイヤーのY座標を伝える
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetPlayerPositionY(int num)
    {
        return players[num].GetY();
    }

    /// <summary>
    /// 指定プレイヤーを殺す
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    public void PlayerDie(int num)
    {
        players[num].Die();
    }
    /// <summary>
    /// 全プレイヤーの生存確認
    /// </summary>
    /// <returns>生存フラグの配列</returns>
    public bool IsLive(int num)
    {
        // プレイヤーの生存フラグを配列にして返す
        return players[num].isLive;
    }

    /// <summary>
    /// ゴール確認
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    /// <returns>ゴールフラグ</returns>
    public bool IsGoal(int num)
    {
        return players[num].isGoal;
    }

    /// <summary>
    /// ゴールした
    /// </summary>
    /// <param name="num">プレイヤー番号</param>
    public void Goal(int num)
    {
        players[num].isGoal = true;
    }

    public void ResetPlayer()
    {
        PlayerInitialize();
    }

    public int GetCurrentTurn()
    {
        return TurnCount;
    }

    public void IncrimentTurn()
    {
        TurnCount++;
    }
}
