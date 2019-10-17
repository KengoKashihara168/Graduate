using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ResultText : MonoBehaviour
{
      [SerializeField] private Text survival;

    //人数
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        for (int i = 0; i < 4; i++)
        {
            //人間かどうか見る
            if(PlayerController.Instance.IsHuman(i))
            {
                //コメント書け
                if (PlayerController.Instance.IsLive(i) == true)
                {
                    //生きている数の算出
                    count++;
               }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        survival.text = "生き残りは" + count;

    }
}
