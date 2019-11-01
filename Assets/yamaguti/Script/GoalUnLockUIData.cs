using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalUnLockUIData : MonoBehaviour
{
    bool infFlag;
    // Start is called before the first frame update
    void Start()
    {
        infFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfFlag(bool flag)
    {
        infFlag = flag;
    }
    public bool IsInfFlag()
    {
        return infFlag;
    }
}
