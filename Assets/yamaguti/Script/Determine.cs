using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Determine : MonoBehaviour
{
    [SerializeField]
    static int Wolf;   //   人狼が誰かを保存しておく変数
    bool hereWolfFlag;
    GameObject map; // マップ用のオブジェクト
                    // Start is called before the first frame update
    void Start()
    {
        hereWolfFlag = false;
        map = GameObject.Find("MapMaster");
        Wolf = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // 死亡確認関数
    public void DetermineDie()
    {
        // 人狼が誰か確認する
        if (!hereWolfFlag)
        {
            for (int i = 0; i < 4; i++)
            {
                // 人かどうか確認
                if (!PlayerController.Instance.IsHuman(i))
                {
                    Wolf = i;   // 人狼の番号を保存
                    hereWolfFlag = true;    // 確認できたらこれ以降ここに入らないようにする
                    break;
                }
            }
        }

        // 誰が噛まれているかの確認する
        for (int i = 0; i < 4; i++)
        {
            // 人かどうか確認
            if (PlayerController.Instance.IsHuman(i))
            {
                // 生きているか確認
                if (PlayerController.Instance.IsLive(i))
                {
                    // ゴールしているか確認
                    if (!PlayerController.Instance.IsGoal(i))
                    {
                        // 場所が一致しているか確認
                        if (MatchCheck(PlayerController.Instance.GetPlayerPositionX(i), PlayerController.Instance.GetPlayerPositionY(i), PlayerController.Instance.GetPlayerPositionX(Wolf), PlayerController.Instance.GetPlayerPositionY(Wolf)))
                        {
                            Debug.Log("プレイヤー" + i + "死亡");
                            PlayerController.Instance.PlayerDie(i);
                        }
                    }
                }
            }
        }
    }
    // ゴール確認関数
    public void DetermineGoal(int player)
    {

        Debug.Log("プレイヤー" + player + "ゴールしました");
        PlayerController.Instance.Goal(player);

    }
    // マップの位置がかぶっているかの確認関数
    public bool MatchCheck(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 && y1 == y2)
        {
            return true;
        }
        return false;
    }


    //人狼と村人が近いか確認する関数
    static public bool WolfCheck()
    {
        //判定用
        int x;
        int y;
  
        for (int i = 0; i < 4; i++)
        {
       
            //狼とゴールもしくは死んだプレイヤーならスキップ
            if(Wolf==i || PlayerController.Instance.IsGoal(i) || !PlayerController.Instance.IsLive(i))
            {
                continue;
            }
            //人狼と村人の位置の差
            x = PlayerController.Instance.GetPlayerPositionX(i) - PlayerController.Instance.GetPlayerPositionX(Wolf);
            y = PlayerController.Instance.GetPlayerPositionY(i) - PlayerController.Instance.GetPlayerPositionY(Wolf);


            //マップの差分が１以下ならtrueを返す
            if ((x <= 1 &&  x >= -1&& y == 0) || (y <= 1 && y >= -1 && x == 0 ))
            {
                return true;
            }
            {
                Debug.Log("プレイヤー"+i);
                return false;
            }
            
        }

        return false;
    }

    // 移動先がゴール
    public bool MoveToGoal(int player)
    {
        if (PlayerController.Instance.IsHuman(player))
        {
            if(MatchCheck(GoalController.Instance.GetPosX((int)GoalId.GOAL), GoalController.Instance.GetPosY((int)GoalId.GOAL), PlayerController.Instance.GetPlayerPositionX(player), PlayerController.Instance.GetPlayerPositionY(player)))
            {
                return true;
            }
        }
        return false;
    }
    // 移動先が鍵
    public bool MoveToKey(int player,ref int key)
    {
        for(int i=0;i<(int)GoalId.GOAL;i++)
        {
            if(GoalController.Instance.GetKeyFlag(i))
            {
                if (PlayerController.Instance.IsHuman(player))
                {
                    if (MatchCheck(GoalController.Instance.GetPosX(i), GoalController.Instance.GetPosY(i), PlayerController.Instance.GetPlayerPositionX(player), PlayerController.Instance.GetPlayerPositionY(player)))
                    {
                        string name = "GoalBut" + (i + 1);
                        Debug.Log(name);
                        
                         key = i;
                         return true;
                    }
                }
            }
        }

        return false;
    }
    // 鍵が開くか確認
    public bool OpenCheck()
    {
        for(int i=0;i<(int)GoalId.GOAL;i++)
        {
            if (GoalController.Instance.GetKeyFlag(i))
            {
                Debug.Log("開かない");
                return false;
            }
              
        }
        return true;
    }

}
