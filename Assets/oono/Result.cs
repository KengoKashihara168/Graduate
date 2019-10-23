using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
   
    }
   public void OnClik()
    {
        PlayerController.Instance.ResetPlayer();
        SceneManager.LoadScene("Job");
    }
}
