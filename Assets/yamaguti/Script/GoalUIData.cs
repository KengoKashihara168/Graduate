using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUIData : MonoBehaviour
{

    public enum Key
    {
        RED,
        BULE,
        YELLOW,
        GLEEN,
        MAXKEY
    }
    [SerializeField]
    public Key myKey;
    Image image;
    SpriteRenderer MainSpriteRenderer;
    // イメージを保存
    Color[] colors4 =
        {
      Color.red,
      Color.blue,
      Color.yellow,
      Color.green,
    };
    bool pressflag;
    // Start is called before the first frame update
    void Start()
    {
        int i = (int.Parse(this.gameObject.name.Substring(7)) - 1);
        GoalId id = (GoalId)i;
        this.gameObject.GetComponentInChildren<Text>().text = id.ToString();
        Debug.Log("画像の名前"+ ("Images/Animal" + i));
       
        this.gameObject.GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Images/Animal" + i) ;
        image = this.gameObject.GetComponent<Button>().image;
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var colors = this.gameObject.GetComponent<Button>().colors;
        colors.normalColor = colors4[(int)myKey];
        colors.highlightedColor = colors4[(int)myKey];
        colors.pressedColor = colors4[(int)myKey];
        colors.selectedColor = colors4[(int)myKey];
        colors.disabledColor = colors4[(int)myKey];
       // this.gameObject.GetComponent<Button>().colors = colors;
        pressflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setpress(bool flag)
    {
        pressflag = flag;
    }
    public bool IsPress()
    {
        return pressflag;
    }
    public SpriteRenderer GetRenderer()
    {
        return MainSpriteRenderer;
    }
    public Image GetImage()
    {
        return image;
    }
}
