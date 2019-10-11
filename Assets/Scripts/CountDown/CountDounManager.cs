using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDounManager : MonoBehaviour
{
    [SerializeField] private GameObject[] playerImages;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < (int)PlayerNum.MaxPlayer;i++)
        {
            if(!PlayerController.Instance.IsLive(i))
            {
                playerImages[i].GetComponent<ImageChange>().Change(1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
