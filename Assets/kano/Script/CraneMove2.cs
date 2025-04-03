using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CraneMove2 : MonoBehaviour
{
    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    [SerializeField] private MagneticForceVariable magneticForceVariable;

    [SerializeField]
    TurnManager turnManager;

    [SerializeField] GameObject UFOanim;
    [SerializeField] GameObject PushAnim;
    [SerializeField] GameObject BrokenPushAnim;

    [SerializeField]
    bool IsHit = false;//景品に当たったか

    [SerializeField]
    int animChangeLine;//Spaceキーが壊れる値
    int pushCount = 0;
    [SerializeField]
    ButtonImageChangeManager ButtonImgChange;

    //クレーンのSEの残り待機時間
    private float remainingTime = 0;

    //ハイスコアタブの表示/非表示
    CheckboxManager checkboxManager;


    Vector2 StartPos = new(-6.3f, 3f);
    Vector2 EndPos = new(6.68f, 3f);
    private enum State
    {
        PUSH,       //プレイヤーが押すターン
        MASHING,    //連打ターン
        DOWN,       //アームを下げる
        WAIT,       //アーム停止
        UP,         //アーム引き上げ
        LEFT,       //横移動
        RELEASE,    //解放　
        RESET,      //全値初期化

        ENUM_END
    }
    private State state;

    float wait = 0.0f;

    private void Start()
    {
        state = State.PUSH;
        UFOanim.SetActive(false);
        PushAnim.SetActive(false);

    }
    private void Update()
    {
        if (!IsPlaying.isPlay) {
            //チェックボックスが更新されたか確認
            //SetPos();
            return; }
        /*
         //fixedにする場合
        bool isKeyDown, isKey, isKeyUp; 
        isKeyDown = Input.GetKeyDown(KeyCode.Space);
        isKey = Input.GetKey(KeyCode.Space);
        isKeyUp = Input.GetKeyUp(KeyCode.Space);
         */

        switch (state)
        {
            case State.PUSH:
                ArmCommand1();
                break;

            case State.MASHING:
                ArmCommand2();
                break;

            case State.DOWN:
                ArmCommand3();
                break;

            case State.WAIT:
                ArmCommand4();
                break;

            case State.UP:
                ArmCommand5();
                break;

            case State.LEFT:
                ArmCommand6();
                break;
            case State.RELEASE:
                ArmCommand7();
                break;

            case State.RESET:
                magneticForceVariable.ResetPushCount();
                magneticForceVariable.Reflection();
                turnManager.TurnCountDown();
                state = State.PUSH;
                break;

            default:
                Debug.Log("なんもしてないのにこわれた");
                break;
        }
    }

    //長押しで横移動のターン
    void ArmCommand1()
    {
        ButtonImgChange.SpriteChange(0);

        //if(isKey){
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            ButtonImgChange.SpriteChange(1);
            transform.position += armSpeed[(int)State.PUSH] * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || EndPos.x <= this.transform.position.x)
        {
            ButtonImgChange.SpriteChange(2);
            wait = 2.0f;
            PushAnim.SetActive(true);
            state++;
        }
    }

    //連打ターン
    void ArmCommand2()
    {
        wait -= Time.deltaTime;

        if (0 < wait)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //磁力を増やす命令
                magneticForceVariable.GetKey();
                pushCount++;
                if (pushCount > animChangeLine) 
                { BrokenPushAnim.SetActive(true);
                    pushCount = 0;
                }
            }
        }
        else if (transform.position.y <= 30 || wait <= 0)
        {
            PushAnim.SetActive(false);
            BrokenPushAnim.SetActive(false) ;

            IsHit = false;
            wait = 5.0f;
            // 降りる効果音再生
            AudioManager.Instance.CraneDownSEPlay();
            UFOanim.SetActive(true);
            state++;
        }
    }

    //降下ターン
    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN] * Time.deltaTime;
        if (IsHit)
        {
            // 1秒後に降下SE停止
            StartCoroutine(StopSoundAfterHit(1.5f));
            state++;
            wait = 3.0f;
        }
    }

    //停止ターン
    void ArmCommand4()
    {
        wait -= Time.deltaTime;
        if (0 > wait)
        {
            // 上昇SE再生
            AudioManager.Instance.CraneUpSEPlay();
            state++;
        }
    }

    //上昇ターン
    void ArmCommand5()
    {
        transform.position += armSpeed[(int)State.UP] * Time.deltaTime;
        if (transform.position.y >= StartPos.y)
        {
            // 上昇SE停止
            AudioManager.Instance.StopCraneSEPlay();
            state++;
        }
    }

    //帰還ターン
    void ArmCommand6()
    {
        transform.position += armSpeed[(int)State.LEFT] * Time.deltaTime;
        if (transform.position.x <= StartPos.x)
        {
            wait = 2;
            UFOanim.SetActive(false);
            state++;
        }
    }

    //手放しターン
    void ArmCommand7()
    {
        magneticForceVariable.MagneticOff();
        wait -= Time.deltaTime;
        if (0 > wait)
        {
            state++;
        }
    }

    //
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsHit = true;
    }

    private IEnumerator StopSoundAfterHit(float waitSeconds)
    {
        remainingTime = waitSeconds;

        while (remainingTime > 0)
        {
            if (IsPlaying.isPlay)
            {
                remainingTime -= Time.deltaTime;
            }
            yield return null;
        }
        AudioManager.Instance.StopCraneSEPlay();
    }

}
