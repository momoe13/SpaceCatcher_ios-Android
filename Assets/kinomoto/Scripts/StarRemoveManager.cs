using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRemoveManager : MonoBehaviour
{
    private void Update()
    {
        //K�L�[���������ۂɐ��̃^�O���t�����I�u�W�F�N�g�����ׂč폜����
        if (Input.GetKey(KeyCode.K))
        {
            AllRemoveStar();
        }
    }
    public void AllRemoveStar()
    {
        //�w�肵���^�O�i���j�̃I�u�W�F�N�g��z��ɓ����
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        //�z��ɓ��ꂽ�I�u�W�F�N�g������J��Ԃ������Ă���
        foreach (GameObject star in stars)
        {
            Destroy(star);
        }
    }
}
