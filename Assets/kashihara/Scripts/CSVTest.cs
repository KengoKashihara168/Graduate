using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVTest : MonoBehaviour
{
    [SerializeField] private TextAsset csvFile; // CSVファイル

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(csvFile.text.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
