using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private Text[] player=new Text [4];

    // プレイヤーの参加人数
    [SerializeField]
    private int playerNum = 4;

    //プレイヤーの今の状態を知るための変数
    string[] nowState = new string [4];

    //プレイヤーが退場(ゴールor死亡)した数
    private int playerExit;

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

            //死んだかゴールしたか
            if (PlayerController.Instance.IsGoal(i) || !PlayerController.Instance.IsLive(i))
            {
                //退場の値を増やす          
                playerExit++;
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
            }
            //ゴールしていないなら
            else
            {
                //まだプレイ中なら
                if (PlayerController.Instance.IsLive(i))
                {
                    //生存と表示
                    nowState[i] = "生存";
                }
                else
                {
                    //死亡と表示
                    nowState[i] = "死亡";
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
    public void OnClick()
    {
   
            //死んだ数とゴールした数が3なら
            if (playerExit >= 3)
            {
                //終了
                Debug.Log("終了");
                SceneManager.LoadScene("Result");
            }
            else
            {
                SceneManager.LoadScene("CountDown");
            }
        
    }
}
