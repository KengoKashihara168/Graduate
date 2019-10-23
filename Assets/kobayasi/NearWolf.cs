using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearWolf : MonoBehaviour
{
   
    [SerializeField]
    private Text nearWolf;

    // Start is called before the first frame update
    void Start()
    {
        //村人の近くに人狼がいるか
        if (Determine.WolfCheck())
        {
            //その情報を表示する
            nearWolf.text = "プレイヤーの近くに人狼がいます";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
