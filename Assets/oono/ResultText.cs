using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ResultText : MonoBehaviour
{
      [SerializeField] private Text survival;

    //人数
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        for (int i = 0; i < 4; i++)
        {

            //ゴールしている人なら
            if (PlayerController.Instance.IsGoal(i) == true)
            {
                //ゴールしている人をカウント
                count++;
            }

        }
        //ゴールしている人数の確認
        if(count>=2)
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
       
    }
    // Update is called once per frame
    void Update()
    {
        
        

    }
}
