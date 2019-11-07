using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ResultText : MonoBehaviour
{
    [SerializeField] private Text survival;

    //人数
    private int count;
    [SerializeField] private int goal;
    [SerializeField] private Text[] player = new Text[(int)PlayerNum.MaxPlayer];
    // Start is called before the first frame update
    [SerializeField]
    private Text goalPos;
    void Start()
    {
        count = 0;
        for (int i = 0; i < (int)PlayerNum.MaxPlayer; i++)
        {

            //ゴールしている人なら
            if (PlayerController.Instance.IsGoal(i) == true)
            {
                //ゴールしている人をカウント
                count++;
            }

        }
        //ゴールしている人数の確認
        if (count >= 2)
        {
            survival.text = " 村人の勝ち";
            //黒にカラー変更
            survival.color = new Color(255.0f, 255.0f, 255.0f);
        }
        else
        {
            //白にカラー変更
            survival.text = " 狼の勝ち";
            survival.color = new Color(0.0f, 0.0f, 0.0f);
        }

        for (int i = 0; i < (int)PlayerNum.MaxPlayer; i++)
        {
            if (PlayerController.Instance.IsHuman(i))
            {
                player[i].text = "プレイヤー" + (i + 1) + "村人";
            }
            else
            {
                player[i].text = "プレイヤー" + (i + 1) + "狼";
            }
        }
        goal = (GoalController.Instance.GetPosX((int)GoalId.GOAL) + ((GoalController.Instance.GetPosY((int)GoalId.GOAL) * 4)) + 1);
        goalPos.text = "ゴールの場所は"+goal;
    }
    // Update is called once per frame
    void Update()
    {



    }
}