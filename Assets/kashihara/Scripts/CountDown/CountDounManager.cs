using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDounManager : MonoBehaviour
{
    [SerializeField] private Text turnText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.IncrimentTurn();
        turnText.text = PlayerController.Instance.GetCurrentTurn().ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
