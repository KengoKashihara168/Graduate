using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Theme : MonoBehaviour
{
    // 外部設定変数
    [SerializeField] private TextAsset csvFile;   // CSVファイル

    // 内部変数
    private Text                       themeText; // テーマテキスト
    private List<string>               texts;     // テキストデータ

    // Start is called before the first frame update
    void Start()
    {
        themeText = GetComponent<Text>();
        texts = new List<string>();
        CsvToTextLine();
        themeText.text = ChoiseRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// CSVファイルを１行毎に読み込む
    /// </summary>
    private void CsvToTextLine()
    {
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            texts.Add(line);
        }
    }

    private string ChoiseRandom()
    {
        int textNum = Random.Range(0, texts.Count);
        if(PlayerController.Instance.GetCurrentTurn()==1)
        {
            textNum = Random.Range(0,2);
        }
        return texts[textNum];
    }
}
