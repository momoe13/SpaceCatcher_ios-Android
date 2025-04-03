using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    [Header("�A�ŏ����̋���")]
    // �X�y�[�X�������ƃJ�E���g�𑝂₷���������Ă��������ǂ���
    public bool isSpace;
    [Header("�A�ŉ�")]
    [SerializeField] private int pushCount = 0;

    [Header("���ݗ͔{��")]
    // �����l
    [SerializeField] private float initialMagnification;
    // ���݂̔{��
    [SerializeField] private float magnificationValue;
    // ���Z����{���l
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("��b�l")]
    // �����l
    [SerializeField] private float initialBase;
    // ���݂̊�b�l
    [SerializeField] private float baseValue;
    // ���Z�����b�l
    [SerializeField] private float addBaseValue = -3f;

    [Header("�ŏI�l")]
    // ���f������Ƃ��̍ŏI�l
    [SerializeField] private float resultValue;

    // �͈͊g�厞�̒l
    [SerializeField] private Vector2[] upPointAry;
    // ���͔͈͂̏����l
    [SerializeField] private Vector2[] initialPointAry;

    void Start()
    {
        // ������
        AllValueReset();
    }

    //void Update()
    //{
    //    // isSpace��true�̊Ԃ̂݁A�A�ŉ񐔉��Z��������
    //    if (isSpace)
    //    {
    //        // �X�y�[�X����������J�E���g�����Z
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            pushCount++;
    //            Reflection();
    //        }
    //        /*-----------------�e�X�g�p�R�}���h-----------------*/
    //        // ���͔͈͊g��
    //        if (Input.GetKeyDown(KeyCode.U))
    //        {
    //            ColliderSizeUp();
    //        }
    //        // ���͔͈͏k��
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            ColliderSizeReset();
    //        }
    //    }        
    //}

    public void GetKey()
    {
        // �X�y�[�X����������J�E���g�����Z
        pushCount++;
        Reflection();
    }
    /// <summary>
    /// ���͂̌��ʔ͈͂̊g��
    /// </summary>
    public void ColliderSizeUp()
    {
        gameObject.GetComponent<PolygonCollider2D>().SetPath(0,upPointAry);
    }

    /// <summary>
    /// ���͂̌��ʔ͈͂̏k��
    /// </summary>
    public void ColliderSizeReset()
    {
        gameObject.GetComponent<PolygonCollider2D>().SetPath(0,initialPointAry);
    }

    /// <summary>
    /// �N���[���̎��͂����S�ɃI�t�ɂ���i�I���ɂ���ꍇReflection()���Ăяo���j
    /// </summary>
    public void MagneticOff()
    {
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = 0;
    }

    /// <summary>
    /// �N���[���̎��͊֌W�̒l��������
    /// </summary>
    public void AllValueReset()
    {
        magnificationValue = initialMagnification;
        baseValue = initialBase;
        pushCount = 0;
        // �N���[���ɔ��f
        Reflection();
    }

    /// <summary>
    /// �N���[���Ɏ��͂̒l�𔽉f�����郁�\�b�h(���͂�߂������ꍇ��������Ăяo���j
    /// </summary>
    public void Reflection()
    {
        // �ŏI�l�̌v�Z
        resultValue = baseValue + ((magnificationValue * pushCount) * baseValue);
        // �v�Z���ꂽ���͂��N���[���ɔ��f������
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// �A�ŉ񐔂̂݃��Z�b�g
    /// </summary>
    public void ResetPushCount()
    {
        pushCount = 0;
    }

    /// <summary>
    /// ���ݗ͔{�������Z����i�p���[�A�b�v�A�C�e���l�����ɌĂяo�����j
    /// </summary>
    public void AddMagnification()
    {
        magnificationValue += addMagnificationValue;
        // �N���[���ɔ��f
        Reflection();
    }


    /// <summary>
    /// ��b�l�����Z����i�p���[�A�b�v�A�C�e���l�����ɌĂяo�����j
    /// </summary>
    public void AddBase()
    {
        baseValue += addBaseValue;
        // �N���[���ɔ��f
        Reflection();
    }
}
