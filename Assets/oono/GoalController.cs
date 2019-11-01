using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    //ゴールのインスタンス
    private static GoalController instance;
    private static Goal[] goals;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static GoalController Instance
    {
        get
        {
            instance = FindObjectOfType<GoalController>();

            if (instance == null)
            {
                GameObject obj = new GameObject("GoalController");
                instance = obj.AddComponent<GoalController>();
                DontDestroyOnLoad(instance);
                GoalInitialize();
            }
            return instance;
        }

        set { }
    }
    //初期化処理
    private static void GoalInitialize()
    {
        goals = new Goal[(int)GoalId.ID_NUM];
        GameObject obj = new GameObject("Goal");
        for (int i = 0; i < goals.Length; i++)
        {
            goals[i] = obj.AddComponent<Goal>();

            goals[i].SetPos(0, 0);
            goals[i].goalId = (GoalId)i;
            goals[i].goalFlag = false;
            goals[i].keyFlag = false;
        }
    }
    // ゴールフラグの設定
    public void SetGoalFlag(bool flag)
    {
        goals[(int)GoalId.GOAL].goalFlag = flag;
    }
    //キーフラグの設定
    //使用するキーはtrue
    public void SetKeyFlag(int num, bool flag)
    {
        goals[num].keyFlag = flag;
    }
    //ゴールフラグの取得
    public bool GetGoalFlag()
    {
        return goals[(int)GoalId.GOAL].goalFlag;
    }

    //キーフラグの取得
    public bool GetKeyFlag(int num)
    {
        return goals[num].keyFlag;
    }
    //ポジションの設定
    public void SetPos(int num, int x, int y)
    {
        goals[num].SetPos(x, y);
    }
    //ポジションXの取得
    public int GetPosX(int num)
    {
        return goals[num].GetPosX();
    }
    //ポジションYの取得
    public int GetPosY(int num)
    {
        return goals[num].GetPosY();
    }

    public void ResetGoal()
    {
        GoalInitialize();
    }
}
