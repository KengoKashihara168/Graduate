using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonClick : MonoBehaviour
{
    GameObject mapObject;
    void Start()
    {
        mapObject = GameObject.Find("MapMaster");
    }
        // ボタンが押された場合、今回呼び出される関数
        public void OnClick()
    {
        if (mapObject.GetComponent<MapPlayerAction>().GetButtonFlag())
        {
            ButtonPos();
        }
    }
    // 呼び出されるとマップ上のプレイヤーの移動が可能か確認できるなら色がつく
    public void ButtonPos()
    {
        MapButtonData map = this.gameObject.GetComponent<MapButtonData>();
        mapObject.GetComponent<MapPlayerAction>().SetInfPlayerPos();
        mapObject.GetComponent<MapPlayerAction>().CheakPos(map.x, map.y,this.gameObject);
        CheckGoal(mapObject.GetComponent<Map>().GetGoalX(), mapObject.GetComponent<Map>().GetGoalY());
    }
    public void CheckGoal(int goalx,int goaly)
    {
        this.gameObject.GetComponent<MapButtonData>().SetGoal(goalx, goaly);
    }
}
