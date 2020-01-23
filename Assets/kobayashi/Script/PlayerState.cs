using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private Text[] player = new Text[4];

    // プレイヤーの参加人数
    [SerializeField]
    private int playerNum = 4;

    //プレイヤーの今の状態を知るための変数
    string[] nowState = new string[4];

    //プレイヤーが退場(ゴールor死亡)した数
    private int playerDeth;
    private int playerGoal;

    //プレイヤーの取得
    [SerializeField]
    private PlayerController playerstate = null;

    // Start is called before the first frame update
    void Start()
    {
        //最初は全員生存
        for (int i = 0; i < playerNum; i++)
        {
            nowState[i] = "生存";

            //プレイヤーがゴールしたか
            if (PlayerController.Instance.IsGoal(i))
            {
                //ゴールカウントを増やす          
                playerGoal++;
            }

            //プレイヤーが死亡したか
            if (!PlayerController.Instance.IsLive(i))
            {
                //死亡カウントを増やす
                playerDeth++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //実行中に値が変わるかの処理
        //キーを押したら(何かが起きた)
        for (int i = 0; i < playerNum; i++)
        {
            //プレイヤーがゴールしたら
            if (PlayerController.Instance.IsGoal(i))
            {
                //ゴールと表示
                nowState[i] = "ゴール";
                player[i].color = new Color(255.0f, 255.0f, 0.0f);
            }
            //ゴールしていないなら
            else
            {
                //まだプレイ中なら
                if (PlayerController.Instance.IsLive(i))
                {
                    //生存と表示
                    nowState[i] = "生存";
                    player[i].color = new Color(0.0f, 255.0f, 50.0f);
                }
                else
                {
                    //死亡と表示
                    nowState[i] = "死亡";
                    player[i].color = new Color(20.0f, 0.0f, 0.0f);
                }
            }

            //ここで実行中に変わるか実験
            if (Input.GetKey(KeyCode.A))
            {
                if (PlayerController.Instance.IsLive(1))
                {
                    nowState[1] = "死亡";
                }
            }

            //画面にプレイヤーと今の状態を表示する
            player[i].GetComponent<Text>().text = "Player" + (i + 1).ToString() + " " + nowState[i].ToString();


        }
    }
    //ボタンでのシーン切り替え
    public void OnClick()
    {
        //死んだ数かゴールした数が2なら
        if (playerDeth >= 2 || playerGoal >= 2)
        {
            //終了
            Debug.Log("終了");
            SceneManager.LoadScene("Result");
        }
        //死亡数とゴールした数が１なら
        else if(playerDeth == 1 && playerGoal == 1)
        {
            //移動シーズン
            SceneManager.LoadScene("MoveScene");
        }
        else
        {
            //話し合いシーンへ
            SceneManager.LoadScene("CountDown");
        }

    }
}
