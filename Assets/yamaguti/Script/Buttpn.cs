using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttpn : MonoBehaviour
{
    public GameObject map;
    [SerializeField]
    public GameObject key;
    [SerializeField]
    public GameObject UI;
    [SerializeField]
    public GameObject nextButton;
    int keynum = 0;
    bool keypanel=false;
    GoalUI goalUI;
    Map mapobj;
    // Start is called before the first frame update
    void Start()
    {
        goalUI = map.GetComponent<GoalUI>();
        mapobj = map.GetComponent<Map>();
    }
    // プレイヤーの位置を表示する関数
    public void OnClick()
    {
        // マップが押されていない状態の時のみ通る
        if(!map.GetComponent<MoveScene>().GetButtonFlag())
        {

            // テキストを表示するフラグをtrueに
            map.GetComponent<MoveScene>().ChengOnTextFlag();
            // マップの色を全てリセット
            mapobj.ResetColor();
            // 今のプレイヤー番号をシーンに渡す
            map.GetComponent<MoveScene>().NowPlayer();
            // プレイヤーの現在地の色を変える
            mapobj.PlayerPosColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()));
            if(PlayerController.Instance.IsHuman(map.GetComponent<MapPlayerAction>().GetName()))
            {
                mapobj.PlayerPosMoveColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()), Color.yellow);
            }
            else
            {
                mapobj.WolfPosMoveColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()), Color.yellow);
            }

            // 移動が完了していない状態にフラグを変えておく
            map.GetComponent<MoveScene>().ChengMoveFlag(false);
            map.GetComponent<MapPlayerAction>().SetButtonFlag(true);
            if (!PlayerController.Instance.IsHuman(map.GetComponent<MoveScene>().GetTotal()))
            {
                if (map.GetComponent<MoveScene>().GetSecurity())
                {
                    map.GetComponent<MoveScene>().enableSecurityText(true);
                    // ゴールの色を変える
                    mapobj.PlayerPosColor(GoalController.Instance.GetPosX((int)GoalId.GOAL), GoalController.Instance.GetPosY((int)GoalId.GOAL), Color.red);               
                }
            }
            nextButton.SetActive(true);
            this.gameObject.SetActive(false);
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
            mapobj.ResetColor();
            mapobj.ResetColor(0, 0);
            // 移動した位置の色を変える
            mapobj.PlayerPosColor(PlayerController.Instance.GetPlayerPositionX(map.GetComponent<MapPlayerAction>().GetName()), PlayerController.Instance.GetPlayerPositionY(map.GetComponent<MapPlayerAction>().GetName()));
            // 移動する際に使った移動先のオブジェクトを破棄
            map.GetComponent<MapPlayerAction>().ResetOldObject();

            // 移動が完了したのでtrueにする
            map.GetComponent<MoveScene>().ChengMoveFlag(true);
            if(PlayerController.Instance.IsHuman(map.GetComponent<MoveScene>().GetTotal()))
            {
                if (map.GetComponent<Determine>().MoveToKey(map.GetComponent<MoveScene>().GetTotal(), ref keynum))
                {
                    key.SetActive(true);
                    keypanel = true;
                    key.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Animal" + keynum);
                }
                // UI解放
                if (map.GetComponent<Determine>().MoveToGoal(map.GetComponent<MoveScene>().GetTotal()))
                {
                    Debug.Log("入っている");
                    goalUI.SetCAlive(true);
                    goalUI.ChengeCheckGoalUI();
                   // map.GetComponent<GoalUI>().SetAlive(true);
                }
            }
            nextButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
       
    }
    // プレイヤーを入れ替える関数
    public void PlayerChaengClick()
    {
        // マップが押されている状態の時のみ通る
        if (map.GetComponent<MoveScene>().GetButtonFlag()&& !goalUI.IsCAlive())
        {
            // テキストを非表示に
            map.GetComponent<MoveScene>().ChengOffTextFlag();

            // 全員の移動が完了したかの確認
            map.GetComponent<MoveScene>().EndPlayer();
            // 次のプレイヤーが誰かを判別する
            map.GetComponent<MoveScene>().NextPlayer();
            // マップの色を全て戻す
            mapobj.ResetColor();
            // 押されていない状態に戻す
            map.GetComponent<MoveScene>().ChengButtonFlag(false);
            key.SetActive(false);
            map.GetComponent<MoveScene>().enableSecurityText(false);
            nextButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
