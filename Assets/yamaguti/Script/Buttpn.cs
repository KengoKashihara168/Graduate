using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttpn : MonoBehaviour
{
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // プレイヤーの位置を表示する関数
    public void OnClick()
    {
        // マップが押されていない状態の時のみ通る
        if(!map.GetComponent<MoveScene>().GetButtonFlag())
        {
            // ゴールが設定されているかどうかの確認
            if (!map.GetComponent<Map>().GoalFlag())
            {
                // ゴールを設定
                map.GetComponent<Map>().SetGoal(SelectJobChangeCharacter.GetPosX(), SelectJobChangeCharacter.GetPosY());
                // ゴールを設定したのでフラグをtrueに
                map.GetComponent<Map>().ChengGoalFlag(true);
            }
            Debug.Log("ごーるだよ" + "Xのほう" + map.GetComponent<Map>().GetGoalX()+ "Yのほう" + map.GetComponent<Map>().GetGoalY());
            // テキストを表示するフラグをtrueに
            map.GetComponent<MoveScene>().ChengOnTextFlag();
            // マップの色を全てリセット
            map.GetComponent<Map>().ResetColor();
            // 今のプレイヤー番号をシーンに渡す
            map.GetComponent<MoveScene>().NowPlayer();
            // プレイヤーの現在地の色を変える
            map.GetComponent<Map>().PlayerPosColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()));
            // 移動が完了していない状態にフラグを変えておく
            map.GetComponent<MoveScene>().ChengMoveFlag(false);
            map.GetComponent<MapPlayerAction>().SetButtonFlag(true);
        }
    }
    // 移動が完了したときに押すボタンの関数
    public void MoveOKClick()
    {
        // マップを選んでいる状態なら通る
        if(map.GetComponent<MapPlayerAction>().GetSelectedFlag())
        {
            // マップが押されている状態でないならtrueにしておく
            if (!map.GetComponent<MoveScene>().GetButtonFlag())
                map.GetComponent<MoveScene>().ChengButtonFlag(true);
            // マップを選んでいないようにする
            map.GetComponent<MapPlayerAction>().SetSelectedFlag(false);
            map.GetComponent<MapPlayerAction>().SetButtonFlag(false);
            // 移動先を取得する
            GameObject next = map.GetComponent<MapPlayerAction>().GetNextMove();
           
            // ここでプレイヤーの居場所変更
            PlayerController.Instance.SetPosition(map.GetComponent<MapPlayerAction>().GetName(), next.GetComponent<MapButtonData>().x, next.GetComponent<MapButtonData>().y);
           
            // 一度すべて色を戻す
            map.GetComponent<Map>().ResetColor();
            // 移動した位置の色を変える
            map.GetComponent<Map>().PlayerPosColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()));
            // 移動する際に使った移動先のオブジェクトを破棄
            map.GetComponent<MapPlayerAction>().ResetOldObject();

            // 移動が完了したのでtrueにする
            map.GetComponent<MoveScene>().ChengMoveFlag(true);
            Debug.Log("OK");
        }
       
    }
    // プレイヤーを入れ替える関数
    public void PlayerChaengClick()
    {
        // マップが押されている状態の時のみ通る
        if (map.GetComponent<MoveScene>().GetButtonFlag())
        {
            // テキストを非表示に
            map.GetComponent<MoveScene>().ChengOffTextFlag();
            // マップの色を全て戻す
            map.GetComponent<Map>().ResetColor();
            // 全員の移動が完了したかの確認
            map.GetComponent<MoveScene>().EndPlayer();
            // 次のプレイヤーが誰かを判別する
            map.GetComponent<MoveScene>().NextPlayer();
            // 押されていない状態に戻す
            map.GetComponent<MoveScene>().ChengButtonFlag(false);
        }
    }
}
