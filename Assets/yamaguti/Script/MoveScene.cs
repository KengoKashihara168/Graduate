﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    int playerTotal; // 今のプレイヤーの番号を置いておく変数
    public Text pName;  // プレイヤー名を表示するためのテキスト変数
    public Text text;   // 役職を表示するためのテキスト変数
    bool textFlag;      // テキストの表示を変えるフラグ
    bool buttonFlag;    // マップ上のボタンがすでに押されているかのフラグ
    bool moveFlag;      // 移動が完了しているかのフラグ
    // Use this for initialization
    void Start()
    {
       
        playerTotal = 0;
        while(!PlayerController.Instance.IsLive(playerTotal)|| PlayerController.Instance.IsGoal(playerTotal))
        {
            playerTotal++;
            if(playerTotal>=4)
            {
                EndPlayer();
            }
        }
       
        textFlag = false;
        buttonFlag = false;
        moveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        pName.text = "プレイヤー" + (playerTotal+1);// プレイヤー名
        if (textFlag)
        {
            pName.enabled = true;
            text.enabled = true;
           
            if (PlayerController.Instance.IsHuman(playerTotal))
            {
                text.text = "村人です";
            }
            else
            {
                text.text = "人狼です";
            }

        }
        else
        {
            //pName.enabled = false;
            text.enabled = false;
        }
    }
    // 次のプレイヤーの生存・ゴール状況を確認してプレイヤーを決める関数
    public void NextPlayer()
    {
        // 最大人数分回っていたら結果に飛ばす
        if(playerTotal>=4)
        {
            EndPlayer();
            return;
        }
        // 死んでいるか
        if (PlayerController.Instance.IsLive(playerTotal))
        {
            // ゴールしているか
            if (PlayerController.Instance.IsGoal(playerTotal))
            {
                // ゴールしているので次のプレイヤーへ
                AddTotal();
                // 次のプレイヤーの生存・ゴール状況を確認
                NextPlayer();
            }
            else
            {
                return;
            }
        }
      else
        {
            // 死んでいるので次のプレイヤーへ
            AddTotal();
            // 次のプレイヤーの生存・ゴール状況を確認
            NextPlayer();
        }
        //  this.gameObject.GetComponent<MapPlayerAction>().SetPlayerInf();
    }
    // 今のプレイヤーの番号を渡す
    public void NowPlayer()
    {
        this.gameObject.GetComponent<MapPlayerAction>().SetPlayerInf(playerTotal);
    }
    // 今のプレイヤー番号をずらす
    public void AddTotal()
    {
        playerTotal++;
    }
    // 今のプレイヤー番号を初期化
    public void ResetTotal()
    {
        playerTotal = 0;
    }
    // 移動終了後に呼ぶ出す関数
    public void EndPlayer()
    {
        // 次のプレイヤーに移す
        AddTotal();
        // プレイヤーが全員行動したら結果へ
        if (playerTotal >= 4)
        {
            // プレイヤーの番号リセット
            ResetTotal();
            // 移動シーン終了
            this.gameObject.GetComponent<Determine>().DetermineDie();  // 死んだ人を殺す 
            this.gameObject.GetComponent<Determine>().DetermineGoal(); // ゴールした人をゴールさせる
            SceneManager.LoadScene("Judgment");
            Debug.Log("終わったよ");
        }
    }
    // マップ上のボタンがすでに押されているかのフラグ------------
    public bool GetButtonFlag()
    {
        return buttonFlag;
    }
    public void ChengButtonFlag(bool flag)
    {
        buttonFlag = flag;
    }
    //-----------------------------------------------------------
    // // 移動が完了しているかのフラグ---------------------------
    public bool GetMoveFlag()
    {
        return moveFlag;
    }
    public void ChengMoveFlag(bool flag)
    {
        moveFlag = flag;
    }
    //-----------------------------------------------------------
    // テキストの表示用のフラグ関数------------------------------
    public void ChengTextFlag()
    {
        textFlag = !textFlag;
    }
    public void ChengOnTextFlag()
    {
        textFlag = true;
    }
    public void ChengOffTextFlag()
    {
        textFlag = false;
    }
    public bool GetTextFlag()
    {
        return textFlag;
    }
    //-----------------------------------------------------------
}