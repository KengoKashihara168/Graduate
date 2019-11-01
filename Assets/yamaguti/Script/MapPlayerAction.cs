using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPlayerAction : MonoBehaviour
{
    int playerName;
    int infX,infY;
    GameObject oldObject;
    bool selected;
    bool mapOnFlag;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        oldObject = null;
        mapOnFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeterminePlayer()
    {

    }
    // 移動できるかの確認関数
    public void CheakPos(int x,int y,GameObject button)
    {
        
        if (PlayerController.Instance.IsHuman(playerName))
        {
          // 村人の場合
            if ((infX + 1 == x && infY == y)||(infX - 1 == x && infY == y)|| (infX == x && infY + 1 == y)|| (infX == x && infY - 1 == y))
            {
                // 前に選択したボタンの色を戻す
                if(oldObject!=null)
                {
                        if (oldObject != button)
                        {
                            ResetColor(oldObject.GetComponent<Button>());
                        }
                }
              

               
                // 位置の色を変える
                var colors = button.GetComponent<Button>().colors;

                colors.normalColor = Color.cyan;
                colors.highlightedColor = Color.cyan;
                colors.pressedColor = Color.cyan;
                colors.selectedColor = Color.cyan;
                colors.disabledColor = Color.cyan;

                button.GetComponent<Button>().colors = colors;
                oldObject = button;
                selected = true;

                Debug.Log("変えるぜ" );

            }
            else if(infX == x && infY == y)
            {
                // 今いる場所
                Debug.Log("今いるよ");
                return;
            }
            else
            {
                Debug.Log("いけないよ");
                return;
            }
        }
        else if (!PlayerController.Instance.IsHuman(playerName))
        {
            // 人狼の場合
            if (infX == x && infY == y)
            {
                Debug.Log("さっきいったよ");
                return;
            }
            else
            {
                // 前に選択したボタンの色を戻す
                if (oldObject != null)
                {
                    if (oldObject != button )
                    {
                        ResetColor(oldObject.GetComponent<Button>());
                    }
                }
                Debug.Log("いけるよ");
                // 位置の色を変える
                var colors = button.GetComponent<Button>().colors;

                colors.normalColor = Color.cyan;
                colors.highlightedColor = Color.cyan;
                colors.pressedColor = Color.cyan;
                colors.selectedColor = Color.cyan;
                colors.disabledColor = Color.cyan;

                button.GetComponent<Button>().colors = colors;
                oldObject = button;
                
                selected = true;
            }

        }
    }

    // 今のプレイヤーの番号を設定
    public void SetPlayerInf(int n)
    {
        playerName = n;
    }

    // 色を変えたプレイヤーの初期位置の色を戻す
    public void ResetColor(Button button)
    {

        var colors = button.colors;

        colors.normalColor = Color.white;
        colors.highlightedColor = Color.white;
        colors.pressedColor = Color.white;
        colors.disabledColor = Color.white;

        button.colors = colors;

    }
    // 移動できるようになっているようにする関数
    public void SetSelectedFlag(bool flag)
    {
        selected = flag;
    }
    public bool GetSelectedFlag()
    {
        return selected;
    }
    public GameObject GetNextMove()
    {
        return oldObject;
    }
    public int GetName()
    {
        return playerName;
    }
    public void SetInfPlayerPos()
    {
        infX = PlayerController.Instance.GetPlayerPositionX(playerName);
        infY = PlayerController.Instance.GetPlayerPositionY(playerName);
    }
    public void ResetOldObject()
    {
        oldObject = null;
    }
    public bool GetButtonFlag()
    {
        return mapOnFlag;
    }
    public void SetButtonFlag(bool flag)
    {
        mapOnFlag = flag;
    }

}
