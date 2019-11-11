using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] private float time;    // タイム
    private Text timeText;                  // テキスト
    private float frameTime;                // 1フレームの経過時間
    private bool push;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();                            // テキストの取得
       // Debug.Assert(time <= 10, "設定時間が10分を超えています。"); // 設定時間の警告
        time *= 60.0f;                                              // 入力値を秒数に修正
        frameTime = Time.deltaTime;
        push = false;
    }

    // Update is called once per frame
    void Update()
    {
        // １フレーム毎に経過時間を減算
        time -= frameTime;

        // 各時間単位を計算
        int minute = (int)(time / 60.0f);                       // 分
        int tenSecond = (int)(time % 60.0f) / 10;               // 秒(十の位)
        int oneSecond = (int)(time % 60.0f) - (tenSecond * 10); // 秒(一の位)

        // 文字列に変換
        string text = minute.ToString() + ":" + tenSecond.ToString() + oneSecond.ToString();
     //   timeText.text = text;

        //カウント消すので一時的なコメント処理
        // タイムアップ
        //if (time <= 0.0f)
        if(push==true) 
        {
            EndCount();
            SceneManager.LoadScene("MoveScene");
        }
    }

    /// <summary>
    /// カウントの終了
    /// </summary>
    public void EndCount()
    {
        //カウント消すので一時的なコメント処理
        //frameTime = 0.0f;
        push = true;
        Debug.Log("終了");
        SceneManager.LoadScene("MoveScene");
    }

    /// <summary>
    /// 時間の加算
    /// </summary>
    public void AddTime()
    {
        if (time >= 540.0f) return; 
        time += 60.0f;
    }
}
