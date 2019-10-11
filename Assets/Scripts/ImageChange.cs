using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    [SerializeField] private bool isArbitrarily; // 子要素の画像を自動で取得するか
    [SerializeField] private List<Image> images; // 画像の配列
    private int enabledImage;                    // 現在有効な画像のインデックス

    // Start is called before the first frame update
    void Start()
    {
        // 画像が設定されていなかったら
        if(images.Count <= 0)
        {
            // 自動取得フラグがONなら
            if (isArbitrarily)
            {
                // すべての子画像を取得
                GetChildImage(transform.GetChild(0));
            }
            else
            {
                // 警告を表示して終了
                Debug.Assert(false, "画像が設定されていません。");
                return;
            }
        }
        
        // 設定された画像を全て無効にする
        foreach (Image str in images)
        {
            str.enabled = false;
        }

        // 最初の画像を有効にする
        enabledImage = 0;
        images[enabledImage].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 画像の切り替え
    /// </summary>
    /// <param name="num">切り替える画像のインデックス</param>
    public void Change(int num)
    {
        // 現在有効な画像を無効にしてnumの画像を有効にする
        images[enabledImage].enabled = false;
        images[num].enabled = true;
        enabledImage = num;
    }

    /// <summary>
    /// 子要素の画像を全て取得（先頭の子要素のみ）
    /// </summary>
    /// <param name="child">子要素</param>
    private void GetChildImage(Transform child)
    {
        // 子要素の画像を取得
        Image childImage = child.GetComponent<Image>();
        images.Add(childImage);

        // さらに子要素があれば
        if(child.childCount > 0)
        {
            // 子要素の画像を取得
            GetChildImage(child.GetChild(0));
        }
    }
}
