using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheckButton : MonoBehaviour
{
    [SerializeField]
    public bool flag;
    [SerializeField]
    public GameObject map;
    GoalUI UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = map.GetComponent<GoalUI>();
    }
    // 
    public void Click()
    {
       if(flag)
        {
            UI.SetAlive(true);
            UI.ChengeGoalUI();
            UI.SetCAlive(false);
            UI.ChengeCheckGoalUI();
        }
       else
        {
            UI.SetCAlive(false);
            UI.ChengeCheckGoalUI();
        }

    }
}
