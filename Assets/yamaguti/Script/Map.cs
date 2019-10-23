using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    const int MAP_TILES = 25;
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
        //for(int i=0;i<3;i++)
        //     CreatePlayerStartPos(1,3);
        goalX = 0;
        goalY = 0;
        //ResetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // プレイヤーの初期位置を決める関数
    public void CreatePlayerStartPos(ref int x,ref int y)
    {
        // 位置をランダムに決める
        int a = Random.Range(0, 24);
        // すでに使われているか確認
        for(int i=0;i<startCount;i++)
        {
            if (startPos[i] == map[a])
            {
                // 使われていたので決めなおし
                a = Random.Range(0, 24);
                continue;
            }
        }
        // 使えたので初期位置を保存しておく
        startPos[startCount] = map[a];
        startCount += 1;

       // Debug.Log("初期位置"+map[a]);

        // 位置の色を変える
        var colors = map[a].colors;

        colors.normalColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);

        colors.highlightedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.pressedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.disabledColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);

        map[a].colors = colors;

        MapButtonData data = map[a].GetComponent<MapButtonData>();
        x = data.x;
        y = data.y;
    }

    // ゴールの初期位置を決める
    public void CreateGoal()
    {
        // ランダムに決める
        int a = Random.Range(0, 24);
        // プレイヤーがいないかどうか確認
        for (int i = 0; i < startCount; i++)
        {
            if (PlayerController.Instance.GetPlayerPositionX(i) == map[a].GetComponent<MapButtonData>().x&& PlayerController.Instance.GetPlayerPositionY(i)==map[a].GetComponent<MapButtonData>().y)
            {
                // いたので決めなおし
                a = Random.Range(0, 24);
                continue;
            }
        }
        //Debug.Log("ゴール" + map[a]);

        // 位置の色を変える
        var colors = map[a].colors;

        colors.normalColor = new Color(255f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.highlightedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.pressedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.disabledColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);

        map[a].colors = colors;

        goalX = map[a].GetComponent<MapButtonData>().x;
        goalY = map[a].GetComponent<MapButtonData>().y;
    }

    //  全ての色を戻す
    public void ResetColor()
    {
        for (int i = 0; i < MAP_TILES; i++)
        {
            var colors = map[i].colors;

            colors.normalColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            colors.highlightedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            colors.pressedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            colors.selectedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            colors.disabledColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

            map[i].colors = colors;
        }
    }
    // 色を変えたプレイヤーの初期位置の色を戻す
    public void ResetColor(int x, int y)
    {
        Button chButton = SearchButton( x,  y);

        var colors = chButton.colors;

        colors.normalColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        colors.highlightedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        colors.pressedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        colors.selectedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        colors.disabledColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

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

        colors.normalColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.highlightedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.pressedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.selectedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.disabledColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);

        Debug.Log(chButton.name);

        chButton.colors = colors;
    }

    // 座標をボタンに直す関数
    public Button SearchButton(int x,int y)
    {
        for (int i = 0; i < MAP_TILES; i++)
        {
            foreach (Transform child in canvas.transform)
            {
                // 子の要素をたどる
                if (child.name == "Map" + (x + (y * 5 + 1)))
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

    public int GetGoalX()
    {
        return goalX;
    }
    public int GetGoalY()
    {
        return goalY;
    }
    public void SetGoal(int x,int y)
    {
        goalX = x;
        goalY = y;
    }
    public bool GoalFlag()
    {
        return nullGoal;
    }
    public void ChengGoalFlag(bool flag)
    {
        nullGoal = flag;
    }
}
