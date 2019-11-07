using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    [SerializeField]
    public GameObject UI;
    [SerializeField]
    public GameObject CheckGoalUI;
    [SerializeField]
    public Button[] allButton;
    bool UIAlive;
    bool checkUIAlive;
    // Start is called before the first frame update
    void Start()
    {
        UIAlive = false;
        checkUIAlive = false;
        foreach (Transform child in UI.transform)
        {
            //child is your child transform
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in CheckGoalUI.transform)
        {
            //child is your child transform
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetAlive(bool alive)
    {
        UIAlive = alive;
    }
    public bool IsAlive()
    {
        return UIAlive;
    }

    public void SetCAlive(bool alive)
    {
        checkUIAlive = alive;
    }
    public bool IsCAlive()
    {
        return checkUIAlive;
    }
    public void ChengeGoalUI()
    {
        if (UIAlive)
        {
            Debug.Log("adsfa");
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
    public void ChengeCheckGoalUI()
    {
        if (checkUIAlive)
        {
            foreach (Transform child in CheckGoalUI.transform)
            {
                //child is your child transform
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in CheckGoalUI.transform)
            {
                //child is your child transform
                child.gameObject.SetActive(false);
            }
        }
    }
}
