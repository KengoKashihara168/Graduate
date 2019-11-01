using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    [SerializeField]
    public GameObject UI;
    [SerializeField]
    public Button[] allButton;
    bool UIAlive;
    // Start is called before the first frame update
    void Start()
    {
        UIAlive = false;
        foreach (Transform child in UI.transform)
        {
            //child is your child transform
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UIAlive)
        {
            foreach (Transform child in UI.transform)
            {
                //child is your child transform
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in UI.transform)
            {
                //child is your child transform
                child.gameObject.SetActive(false);
            }
        }
    }
    public void SetAlive(bool alive)
    {
        UIAlive = alive;
    }
    public bool IsAlive()
    {
        return UIAlive;
    }
}
