using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUIButton : MonoBehaviour
{
    [SerializeField]
    public GameObject map;
    [SerializeField]
    public Button[] button;
    [SerializeField]
    public Sprite newimage;

    Image GoalUnlockUIImage1;
    Image GoalUnlockUIImage2;
   
    int keyNumOne;
    int keyNumTw;
    GameObject Unlock1, Unlock2;
    // Start is called before the first frame update
    void Start()
    {
        keyNumOne = (int)GoalId.ID_NUM;
        keyNumTw = (int)GoalId.ID_NUM;
        Unlock1 = GameObject.Find("UnLock1");
        Unlock2 = GameObject.Find("UnLock2");
        GoalUnlockUIImage1 = Unlock1.GetComponent<Image>();
        GoalUnlockUIImage2 = Unlock2.GetComponent<Image>();
    }
    // 
    public void UnLockClick()
    {
        if(Unlock1.GetComponent<GoalUnLockUIData>().IsInfFlag()&& Unlock2.GetComponent<GoalUnLockUIData>().IsInfFlag())
        {
            map.GetComponent<GoalUI>().SetAlive(false);
            if (map.GetComponent<Determine>().OpenCheck())
            {
                Debug.Log("ゴールした");
                PlayerController.Instance.Goal(map.GetComponent<MoveScene>().GetTotal());
            }
            else
            {
                GoalController.Instance.SetGoalFlag(true);
            }
            ResetFlag();
            ResetImage();
        }
       
    }
    public void PassClick()
    {
        if (!this.gameObject.GetComponent<GoalUIData>().IsPress())
        {
            Debug.Log("押した");
            this.gameObject.GetComponent<GoalUIData>().setpress(true);
            Debug.Log(int.Parse(this.gameObject.name.Substring(7)) - 1);
            if (GoalController.Instance.GetKeyFlag(int.Parse(this.gameObject.name.Substring(7))-1))
            {
                Debug.Log(this.name);
                GoalController.Instance.SetKeyFlag(int.Parse(this.gameObject.name.Substring(7))-1, false);
                if (keyNumOne == (int)GoalId.ID_NUM)
                {
                    keyNumOne = int.Parse(this.gameObject.name.Substring(7)) - 1;
                    Debug.Log("aasda"+keyNumOne);
                }
                else if (keyNumTw == (int)GoalId.ID_NUM)
                {
                    keyNumTw = int.Parse(this.gameObject.name.Substring(7)) - 1;
                    Debug.Log("aasda222" + keyNumTw);
                }
                  
            }
            if (!Unlock1.GetComponent<GoalUnLockUIData>().IsInfFlag())
            {
                Unlock1.GetComponent<GoalUnLockUIData>().SetInfFlag(true);
                GoalUnlockUIImage1.sprite = this.gameObject.GetComponent<GoalUIData>().GetImage().sprite;
            }
            else if (!Unlock2.GetComponent<GoalUnLockUIData>().IsInfFlag())
            {
                Unlock2.GetComponent<GoalUnLockUIData>().SetInfFlag(true);
                GoalUnlockUIImage2.sprite = this.gameObject.GetComponent<GoalUIData>().GetImage().sprite;
            }

        }
    }
    public void BackClick()
    {
        ResetImage();
        ResetFlag();
    }
    public void NotClick()
    {
        map.GetComponent<GoalUI>().SetAlive(false);
        ResetImage();
        ResetFlag();
    }
    public void ResetImage()
    {
        if (Unlock1.GetComponent<GoalUnLockUIData>().IsInfFlag())
        {
            Unlock1.GetComponent<GoalUnLockUIData>().SetInfFlag(false);
            GoalUnlockUIImage1.sprite = newimage;
        }
        if (Unlock2.GetComponent<GoalUnLockUIData>().IsInfFlag())
        {
            Unlock2.GetComponent<GoalUnLockUIData>().SetInfFlag(false);
            GoalUnlockUIImage2.sprite = newimage;
        }
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<GoalUIData>().setpress(false);
        }

    }
    public void ResetFlag()
    {
        for(int i=0;i<button.Length;i++)
        {
            if (button[i].GetComponent<GoalUIButton>().keyNumOne != (int)GoalId.ID_NUM)
            {
                GoalController.Instance.SetKeyFlag(button[i].GetComponent<GoalUIButton>().keyNumOne, true);
                Debug.Log(button[i].GetComponent<GoalUIButton>().keyNumOne);
            }

            if (button[i].GetComponent<GoalUIButton>().keyNumTw != (int)GoalId.ID_NUM)
            {
                GoalController.Instance.SetKeyFlag(button[i].GetComponent<GoalUIButton>().keyNumTw, true);
                Debug.Log(button[i].GetComponent<GoalUIButton>().keyNumTw);
            }
            button[i].GetComponent<GoalUIButton>().keyNumOne = (int)GoalId.ID_NUM;
            button[i].GetComponent<GoalUIButton>().keyNumTw = (int)GoalId.ID_NUM;
        } 
    }
}
