using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    private Text turnText;

    // Start is called before the first frame update
    void Start()
    {
        turnText = GetComponent<Text>();
        PlayerController.Instance.IncrimentTurn();
        turnText.text = PlayerController.Instance.GetCurrentTurn().ToString() + "ターン";
    }
}
