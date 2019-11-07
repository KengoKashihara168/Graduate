using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    const int MAP_TILES = 16;
    const int MAX_PLAYER = 4;
    public Canvas canvas;
    Button[] map= new Button[MAP_TILES];
    Button[] startPos = new Button[MAX_PLAYER];
    bool nullGoal;
    int goalX;
    int goalY;
    int startCount;
    // Start is called before the first frame update
    void Start()
    {
        startCount = 0;
        nullGoal = false;
        // Canvasコンポーネントを保持
        //canvas = GetComponent<Canvas>();
        for (int i = 0; i < MAP_TILES; i++)
        {

            foreach (Transform child in canvas.transform)
            {
                // 子の要素をたどる
                if (child.name == "Map" + (1 + i))
                {
                    // 指定した名前と一致
                    // Buttonコンポーネントを取得する
                    map[i] = child.gameObject.GetComponent<Button>();
                   // Debug.Log(map[i]);
                }               
            }
        }
        goalX = 0;
        goalY = 0;
        //ResetColor();
    }  

    //  全ての色を戻す
    public void ResetColor()
    {
        for (int i = 0; i < MAP_TILES; i++)
        {
            var colors = map[i].colors;

            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            colors.selectedColor = Color.white;
            colors.disabledColor = Color.white;

            map[i].colors = colors;
        }
    }
    // 色を変えたプレイヤーの初期位置の色を戻す
    public void ResetColor(int x, int y)
    {
        Button chButton = SearchButton( x,  y);

        var colors = chButton.colors;

        colors.normalColor = Color.white;
        colors.highlightedColor = Color.white;
        colors.pressedColor = Color.white;
        colors.selectedColor = Color.white;
        colors.disabledColor = Color.white;

        chButton.colors = colors;
    }
    // プレイヤーの位置の色を変える
    public void PlayerPosColor(int x, int y)
    {
        Button chButton = SearchButton(x, y);
        if (x == -1 && y == -1)
        {
            chButton = SearchButton(0, 0);
        }

        var colors = chButton.colors;

        colors.normalColor = Color.green;
        colors.highlightedColor = Color.green;
        colors.pressedColor = Color.green;
        colors.selectedColor = Color.green;
        colors.disabledColor = Color.green;
        chButton.colors = colors;
    }
    // 色指定可能な関数
    public void PlayerPosColor(int x, int y,Color color)
    {
        Button chButton = SearchButton(x, y);
        if (x == -1 && y == -1)
        {
            chButton = SearchButton(0, 0);
        }

        var colors = chButton.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        colors.selectedColor = color;
        colors.disabledColor = color;

        Debug.Log(chButton.name);

        chButton.colors = colors;
    }

    // 色指定可能な関数
    public void PlayerPosMoveColor(int x, int y, Color color)
    {
        int pulusX = x + 1;
        int pulusY = y + 1;
        int minusX = x - 1;
        int minusY = y - 1;
        Button chButton = SearchButton(x, y);
        for (int i=0;i<4;i++)
        {
            switch (i)
            {
                case 0:
                    chButton = SearchButton(pulusX, y);
                    if (pulusX > 3)
                        continue;
                    break;
                case 1:
                    chButton = SearchButton(x, pulusY);
                    if (pulusY > 3)
                        continue;
                    break;
                case 2:
                    chButton = SearchButton(minusX, y);
                    if(minusX<0)
                        continue;
                    break;
                case 3:
                    chButton = SearchButton(x, minusY);
                    if (minusY < 0)
                        continue;
                    break;
            }
            var colors = chButton.colors;
            colors.normalColor = color;
            colors.highlightedColor = color;
            colors.pressedColor = color;
            colors.selectedColor = color;
            colors.disabledColor = color;

            chButton.colors = colors;
        }
       
    }
    public void WolfPosMoveColor(int x, int y, Color color)
    {
        Button chButton = SearchButton(x, y);
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == x && j == y)
                {
                    continue;
                }
                chButton = SearchButton(i, j);
                var colors = chButton.colors;
                colors.normalColor = color;
                colors.highlightedColor = color;
                colors.pressedColor = color;
                colors.selectedColor = color;
                colors.disabledColor = color;
                chButton.colors = colors;
            }
        }

    }

    // 座標をボタンに直す関数
    public Button SearchButton(int x,int y)
    {
        for (int i = 0; i < MAP_TILES; i++)
        {
            foreach (Transform child in canvas.transform)
            {
                // 子の要素をたどる
                if (child.name == "Map" + (x + (y * 4 + 1))) // この値を直すとマス目を変えられる
                {
                    // 指定した名前と一致
                    // Buttonコンポーネントを取得する
                    Button mm= map[i] = child.gameObject.GetComponent<Button>();
                    return mm;
                    // Debug.Log(map[i]);
                }
            }
        }
        return map[0];
        
    }

    // ゴールゲッター
    public int GetGoalX()
    {
        return goalX;
    }
    public int GetGoalY()
    {
        return goalY;
    }

    // ゴールセッター
    public void SetGoal(int x,int y)
    {
        goalX = x;
        goalY = y;
    }
    // ゴールが存在するかのフラグ
    public bool GoalFlag()
    {
        return nullGoal;
    }
    // ゴールが存在するかのフラグのチェンジ用
    public void ChengGoalFlag(bool flag)
    {
        nullGoal = flag;
    }
}
