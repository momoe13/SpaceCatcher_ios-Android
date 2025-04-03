using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public GameObject turnObject = null;
    public float turnCount = 3;
    private bool isLoadScene = false;

    private void Start()
    {
        //������
    }

    private void Update()
    {
        Text turnText = turnObject.GetComponent<Text>();
        turnText.text = turnCount.ToString();//�c��^�[������\��

        // Debug.Log(turnCount);
        if (turnCount <= 0)
        {
            if (!isLoadScene)
            {
                TestParticle.Instance.fadeCall();
                isLoadScene = true;
            }
            //�Q�[�����I��
        }


    }
    /// <summary>
    /// �^�[�����̃J�E���g����
    /// </summary>
    public void TurnCountDown()
    {
        turnCount--;
    }


    /// <summary>
    /// �^�[�����̃J�E���g�㏸
    /// </summary>
    public void TurnCountUp()
    {
        turnCount += 1;
    }

    public void ItemGetTurnCountUp()
    {
        turnCount += 3;
    }
}
