using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;


public class CraneMove2 : MonoBehaviour
{
    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    [SerializeField] private MagneticForceVariable magneticForceVariable;

    [SerializeField] private Gauge gauge;


    [SerializeField]
    TurnManager turnManager;

    [SerializeField] GameObject UFOanim;
    [SerializeField] GameObject PushAnim;
    [SerializeField] GameObject BrokenPushAnim;

    [SerializeField]
    bool IsHit = false;//�i�i�ɓ���������

    [SerializeField]
    int animChangeLine;//Space�L�[������l
    int pushCount = 0;
    [SerializeField]
    ButtonImageChangeManager ButtonImgChange;

    //�N���[����SE�̎c��ҋ@����
    private float remainingTime = 0;

    //�n�C�X�R�A�^�u�̕\��/��\��
    CheckboxManager checkboxManager;


    Vector2 StartPos = new(-4.2f, 3f);

    Vector2 EndPos = new(6.68f, 3f);
    private enum State
    {
        PUSH,       //�v���C���[�������^�[��
        MASHING,    //�A�Ń^�[��
        DOWN,       //�A�[����������
        WAIT,       //�A�[����~
        UP,         //�A�[�������グ
        LEFT,       //���ړ�
        RELEASE,    //����@
        RESET,      //�S�l������

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
            //�`�F�b�N�{�b�N�X���X�V���ꂽ���m�F
            //SetPos();
            return; }
        /*
         //fixed�ɂ���ꍇ
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
                Debug.Log("�Ȃ�����ĂȂ��̂ɂ���ꂽ");
                break;
        }
    }

    //�������ŉ��ړ��̃^�[��
    void ArmCommand1()
    {
        ButtonImgChange.SpriteChange(0);

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !UIHoverTracker.IsPointerOverButton)

        {
            ButtonImgChange.SpriteChange(1);
            transform.position += armSpeed[(int)State.PUSH] * Time.deltaTime;
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || EndPos.x <= this.transform.position.x) && !UIHoverTracker.IsPointerOverButton)

        {
            ButtonImgChange.SpriteChange(2);
            wait = 2.0f;
            PushAnim.SetActive(true);
            state++;
        }
    }

    //�A�Ń^�[��
    void ArmCommand2()
    {
        wait -= Time.deltaTime;

        if (0 < wait)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !UIHoverTracker.IsPointerOverButton)

            {
                //���͂𑝂₷����
                magneticForceVariable.GetKey();
                pushCount++;
                if (pushCount > animChangeLine) 

                {
                    PushAnim.SetActive(false);
                    BrokenPushAnim.SetActive(true);

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
            // �~�����ʉ��Đ�
            AudioManager.Instance.CraneDownSEPlay();
            UFOanim.SetActive(true);
            state++;
        }
    }

    //�~���^�[��
    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN] * Time.deltaTime;
        if (IsHit)
        {
            // 1�b��ɍ~��SE��~
            StartCoroutine(StopSoundAfterHit(1.5f));
            state++;
            wait = 3.0f;
        }
    }

    //��~�^�[��
    void ArmCommand4()
    {
        wait -= Time.deltaTime;
        if (0 > wait)
        {
            // �㏸SE�Đ�
            AudioManager.Instance.CraneUpSEPlay();
            state++;
        }
    }

    //�㏸�^�[��
    void ArmCommand5()
    {
        transform.position += armSpeed[(int)State.UP] * Time.deltaTime;
        if (transform.position.y >= StartPos.y)
        {
            // �㏸SE��~
            AudioManager.Instance.StopCraneSEPlay();
            state++;
        }
    }

    //�A�҃^�[��
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

    //������^�[��
    void ArmCommand7()
    {

        gauge.GaugeReset();

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
