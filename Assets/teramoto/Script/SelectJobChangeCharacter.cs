using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectJobChangeCharacter : MonoBehaviour
{


    //リストに数値を入れる。
    List<int> numbers = new List<int>();
   
    //人間かどうか
    bool IsHuman;
    
    //job表示フラグ
    private bool IsJobButtonTouch;

    //Charctor表示フラグ
    private bool IsCharctorButtonTouch;

    //postion表示フラグ
    private bool IsPostionButtomTouch;

    // GameObjectを保持する配列の生成
    GameObject[] playerImageList = new GameObject[4];

    // GameObjectを保持する配列の生成
    GameObject[] playerJobImageList = new GameObject[2];

    //プレイヤー1の画像
    [SerializeField]
    private Text a = null;

    //プレイヤー1の画像
    [SerializeField]
    private GameObject playerImage1 = null;

    //プレイヤー2の画像
    [SerializeField]
    private GameObject playerImage2 = null;

    //プレイヤー3の画像
    [SerializeField]
    private GameObject playerImage3 = null;

    //プレイヤー4の画像
    [SerializeField]
    private GameObject playerImage4 = null;

    //プレイヤーjob決定用ボタン
    [SerializeField]
    private GameObject PlayerJobButton = null;

    //プレイヤー変更用ボタン
    [SerializeField]
    private GameObject PlayerChangeButton = null;

    //プレイヤー変更用ボタン
    [SerializeField]
    private GameObject MoveSceneButton = null;

    //プレイヤー変更用ボタン
    [SerializeField]
    private GameObject PlayerPosDecisionButton;

    //人間の画像
    [SerializeField]
    private GameObject HumanImage = null;
   
    //狼の画像
    [SerializeField]
    private GameObject WolfImage = null;

    static int MAXPLAYER = 4;
    //押された数
    [SerializeField]
    private int pushcount = -1;

    //全員の役職が決まったフラグ
    bool jobDecision;

    //ゴールの場所の決定
    bool IsGoalDecision;

    //決定したポジション分のカウント
    int posCount;

    static int x, y;
    //postion確保用配列

    //リストに数値を入れる。
    List<int> posListX = new List<int>();
    //リストに数値を入れる。
    List<int> posListY = new List<int>();


    static int MAX_SIZE_X = 4;
    static int MAX_SIZE_Y = 4;

    bool IsMoveScene;
    string name;


    // Start is called before the first frame update

    //--------------------------------------------------
    //初期化用
    //--------------------------------------------------

    void Start()
    {
        //Playerのジョブボタンの非表示化
        PlayerJobButton.SetActive(false);

        //Playerのジョブボタンの表示化
        PlayerChangeButton.SetActive(true);
        MoveSceneButton.SetActive(false);

        //Listの中にImageを挿入する。
        playerImageList[0] = playerImage1;
        playerImageList[1] = playerImage2;
        playerImageList[2] = playerImage3;
        playerImageList[3] = playerImage4;

        //Listの中にImageを挿入する。
        playerJobImageList[0] = HumanImage;
        playerJobImageList[1] = WolfImage;

        //プレイヤーの画像の非表示
        for (int i = 0; i < MAXPLAYER; i++)
        {
            numbers.Add(i);
            //プレイヤーのImageLiseの表示を非表示にする。
            playerImageList[i].SetActive(false);
        }
        
        //全Characterの役職が決まったか
        jobDecision = false;

        //ゴールの場所が決まったとき用
        IsGoalDecision = false;

    }

//--------------------------------------------------
//更新よう
//--------------------------------------------------

    // Update is called once per frame
    void Update()
    {

        //pushカウントが押されていないとき
        if (pushcount == 0)
        {       
            //何も押されてない場合最初の人へを表示
            PlayerChangeButton.GetComponentInChildren<Text>().text = "最初の人へ";
        }
        else if (pushcount <MAXPLAYER)
        {
            //4回押されてない場合次の人へを表示
            PlayerChangeButton.GetComponentInChildren<Text>().text = "次の人へ";

        }



        //Jobボタン
        if (pushcount < MAXPLAYER + 1 && IsJobButtonTouch == true)
        {
            //役職決定用ボタン
            PushJobButton();
        }
        //Spaceがおされ4回以内なら
        if (IsCharctorButtonTouch && pushcount < MAXPLAYER)
        {
            //役職決定用決定用ボタン
            PushCharctorButton();
        }
        if (IsPostionButtomTouch && pushcount < MAXPLAYER + 1)
        { 
            PushPositionButton();
        }

        //全員の場所が決まったら
        if (pushcount >= MAXPLAYER && posCount>=MAXPLAYER && !IsGoalDecision)
        {

            //四人目とゴールをけっていする。




            //jobDecision = true;
            //ゴールを決める
            SetitngGoal();


            Debug.Log("aaaxxx");
        }


        if(IsGoalDecision)
        {
            DistancePlayerToGoal();
            PlayerChangeButton.GetComponentInChildren<Text>().text = "ゴールから一番近いのは";
        }


        if (pushcount>=MAXPLAYER+1)
        {
            //ここでボタンをだす。
            MoveSceneButton.SetActive(true);
           
        }
    }

    //Goalの場所
    void SetitngGoal()
    {
        int x1 = Random.Range(0, MAX_SIZE_X);
        int y1 = Random.Range(0, MAX_SIZE_Y);

        for (int i = 0; i < posListX.Count; i++)
        {
            if (x1 == posListX[i] && y1 == posListY[i])
            {
                x1 = Random.Range(0, MAX_SIZE_X);
                y1 = Random.Range(0, MAX_SIZE_Y);
                i = -1;
                continue;
            }
        }

        IsGoalDecision = true;
        x = x1;
        y = y1;
        posListX.Add(x1);
        posListY.Add(y1);
        GoalController.Instance.SetPos((int)GoalId.GOAL, x, y);
        print("Goalの場所は" + ((x1 + (y1 * 4)) + 1));
    }

    //----------------------------------------------------------------
    //キー用
    //----------------------------------------------------------------
    void SetingKey()
    {

        int x1 = Random.Range(0, MAX_SIZE_X);
        int y1 = Random.Range(0, MAX_SIZE_Y);
        int num = Random.Range(0, 4);
        int save = -1;
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < posListX.Count; i++)
            {
                if (x1 == posListX[i] && y1 == posListY[i])
                {


                    x1 = Random.Range(0, MAX_SIZE_X);
                    y1 = Random.Range(0, MAX_SIZE_Y);
                    i = -1;
                    continue;
                    
                }
            }

            if (save == num)
            {
                num = Random.Range(0, 4);
                j -= 1;
                continue;
            }
            GoalController.Instance.SetKeyFlag(num, true);
            GoalController.Instance.SetPos(num, x1, y1);
            posListX.Add(x1);
            posListY.Add(y1);
            save = num;
            print("Key" + num + "の場所は" + "Xが" + GoalController.Instance.GetPosX(num) + "Yが" + GoalController.Instance.GetPosY(num));
        }
    }


    //----------------------------------------------------------------
    //ボタン用
    //----------------------------------------------------------------

    //Charctorボタンを押されたときよう処理
    void PushCharctorButton()
    {
        //該当のCharacterイメージの表示
        playerImageList[pushcount].SetActive(true);

        //カウントを+する。
        pushcount += 1;
        //Characterボタン押されたフラグをfalseにする。
        IsCharctorButtonTouch = false;
        a.text = "";
    }

    //役職決め用ボタンを押されたときよう処理
    void PushJobButton()
    {
        //乱数決め
        int index = Random.Range(0, numbers.Count);
        //配列に乱数を入れる。
        int ransu = numbers[index];
        //要素削除
        numbers.RemoveAt(index);

        //乱数を回す
        roulette(ransu);
        //Jobボタン押されたフラグをfalseにする。
        IsJobButtonTouch = false;

    }

    //場所決め用ボタンを押されたときよう処理
    void PushPositionButton()
    {

        if (IsHuman == true)
        {
            HumanPosition();
        }   
        else
        {
            //狼用
            print("おおかみだからありましぇーん");
            HumanPosition();
          
            //何もなし！！！！！

        }

        posCount += 1;

        //Jobボタン押されたフラグをfalseにする。
        IsPostionButtomTouch = false;

    }

    //Scene変更用を押されたときよう処理
    void PushMoveSceneButton()
    {
        //Scene遷移
        SceneManager.LoadScene("CountDown");

    }


    //--------------------------------------------------------------
    //ボタン押されたあと
    //--------------------------------------------------------------

    //Characterボタンを押された時の関数
    public void OnClickCharacterButton()
    {
        if (IsGoalDecision)
        {
            a.text = name;
            MoveSceneButton.SetActive(true);
        }
        else
        {
            //Character表示用Flagをtrueにする。
            IsCharctorButtonTouch = true;
            //ジョブボタンの表示
            PlayerJobButton.SetActive(true);
            //キャラ変更ボタンの非表示
            PlayerChangeButton.SetActive(false);
            //Characterの場所決定ボタン
            PlayerPosDecisionButton.SetActive(false);
        }
    }

    //ジョブボタンを押された時の関数
    public void OnClickJobButton()
    {
        if (!jobDecision)
        {

            //ジョブ表示をひらいた場合
            //プレイヤーの画像を表示しない
            // ループして、オブジェクト名をログに出力
            foreach (GameObject i in playerImageList)
            {
                i.SetActive(false);
            }
            //Job表示用Flagをtrueにする。
            IsJobButtonTouch = true;
            //ジョブボタンの非表示
            PlayerJobButton.SetActive(false);
            //キャラ変更ボタンの表示
            PlayerChangeButton.SetActive(false);
            //Characterの場所決定ボタン
            PlayerPosDecisionButton.SetActive(true);
        }


    }

    //Position決定用ボタンを押されたときの関数
    public void OnClickPositionButton()
    {      
        if(!jobDecision)
        {
            //Character表示をひらいた場合
            //プレイヤーの役職の画像を表示しない
            // ループして、オブジェクト名をログに出力
            foreach (GameObject i in playerJobImageList)
            {
                i.SetActive(false);
            }


            //Position表示用Flagをtrueにする。
            IsPostionButtomTouch = true;

            //ジョブボタンの表示
            PlayerJobButton.SetActive(false);
            //キャラ変更ボタンの非表示
            PlayerChangeButton.SetActive(true);
            //Characterの場所決定ボタン
            PlayerPosDecisionButton.SetActive(false);

        }

    }
    //Scene移動ボタンを押されたときの関数
    public void OnClickPushMoveScene()
    {
        IsMoveScene = true;
        //ジョブボタンの表示
        PlayerJobButton.SetActive(false);
        //キャラ変更ボタンの非表示
        PlayerChangeButton.SetActive(false);
        //Characterの場所決定ボタン
        PlayerPosDecisionButton.SetActive(false);
        PushMoveSceneButton();
    }


    //--------------------------------------------------------------
    //Stage関連
    //--------------------------------------------------------------

    //人間の場所
    void HumanPosition()
    {
        int x1 = Random.Range(0, MAX_SIZE_X);
        int y1 = Random.Range(0, MAX_SIZE_Y);

       for( int i = 0; i < posListX.Count; i++)
        {
            if(x1 == posListX[i] && y1 == posListY[i])
            {
                x1 = Random.Range(0, MAX_SIZE_X);
                y1 = Random.Range(0, MAX_SIZE_Y);
                i = -1;
                continue;
            }


        }

        posListX.Add(x1);
        posListY.Add(y1);



        //プレイヤーに情報代入
        PlayerController.Instance.SetPosition(pushcount - 1, posListX[posListX.Count - 1], posListY[posListY.Count - 1]);
        a.text = "プレイヤーの初期位置は" +((x1 + (y1 * 4)) + 1);
        print("Player"+( pushcount)+ "の場所は" + ((x1 + (y1 * 4)) + 1));

    }


//--------------------------------------------------------------
//Getter関数
//--------------------------------------------------------------

    //役職が決まったかのゲッター関数
    public bool IsJobDecision()
    {
        return jobDecision;
    }
    //プッシュカウント取得用ゲッター関数
    public int GetPushCount()
    {
        return pushcount;
    }

    //GoalのX座標
    static public int GetPosX()
    {
        return x;
    }

    //GoalのY座標
    static public int GetPosY()
    {
        return y;
    }

    //--------------------------------------------------------------
    //roulette用
    //--------------------------------------------------------------
    //役職決め
    void roulette(int rand)
    {
        switch (rand)
        {
            case 0:
                //プレイヤーを人間に変更
                RoleHuman();
                break;


            case 1:
                //プレイヤーを狼に変更
                RoleWolf();
                PlayerController.Instance.SetWolf(pushcount-1);
                break;

            case 2:
                //プレイヤーを人間に変更
                RoleHuman();
                break;

            case 3:
                //プレイヤーを人間に変更
                RoleHuman();
                break;

            case 4:
                //プレイヤーを人間に変更
                RoleHuman();
                break;

            default:
                RoleHuman();
                break;
        }
    }


    void DistancePlayerToGoal()
    {
            //GoalとPlayerの場所の比較
            int pos1 = 5, pos2 = 5;
            int fPos1 = 0, fPos2 = 0;
            Vector2 posA = new Vector2(pos1, pos2);
            Vector2 posB = new Vector2(fPos1, fPos2);

            float distance = (posA - posB).magnitude;

            pos1 = x;
            pos2 = y;
            //差の算出
            for (int i = 0; i < 4; i++)
            {

                fPos1 = PlayerController.Instance.GetPlayerPositionX(i);
                //print("elsefPos1" + fPos1);

                fPos2 = PlayerController.Instance.GetPlayerPositionY(i);
                //print("fPos2" + fPos2);

                posA = new Vector2(pos1, pos2);
                posB = new Vector2(fPos1, fPos2);

                //distance = (posA - posB).magnitude;

                if (distance >= (posA - posB).magnitude)
                {
                    distance = (posA - posB).magnitude;
                    name = "プレイヤー" + (i + 1);

                }

            }
            //比較後それを出す

            //a.text = name;
           // print(name);
    }
//-----------------------
//役職別
//人間用
//-----------------------

    //人間の役職
    void RoleHuman()
    {
        //人間用フラグをOnにする。
        IsHuman = true;
        //狼の画像をOfにする。
        WolfImage.SetActive(false);
        //人間の画像をOnにする。
        HumanImage.SetActive(true);
    }
//-----------------------
//役職別
//狼用
//-----------------------

    //狼の役職
    void RoleWolf()
    {
        //人間用フラグをOfにする。
        IsHuman = false;
        //狼の画像をOnにする。
        WolfImage.SetActive(true);
        //人間の画像をOfにする。
        HumanImage.SetActive(false);


    }


}
