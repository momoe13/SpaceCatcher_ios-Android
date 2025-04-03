using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] 
    public List<GameObject> targetSelect;//�N���A�ڕW�̃A�C�e���̃��X�g
    public int TargetNumber;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//C�������ĖڕW���w��i���j
        {
            TargetRandomSelect();
        }
    }

    public void TargetRandomSelect()
    {
        //���X�g�̒����烉���_���Ɉ���I�΂��
        TargetNumber = Random.Range(0, targetSelect.Count);
        Debug.Log("�ڕW�̃A�C�e����" + targetSelect[TargetNumber]);
    }
}
