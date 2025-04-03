using UnityEngine;
using UnityEngine.UI;

public class TargetItem : MonoBehaviour
{
    [SerializeField] GameObject[] PrfbItems; //�v���C�Y�A�C�e���̔z��

    [SerializeField] int[] ItemNumbers;�@�@//�v���C�Y�A�C�e���̔ԍ�

    [SerializeField] GameObject[] PowerItems;    //�����p�A�C�e��

    [SerializeField] public GameObject[] PushItem;//�V�[���ɓo�ꂳ����A�C�e��

    [SerializeField]public int targetNum;�@�@�@�@//�ڕW�ƂȂ�A�C�e���ԍ�

    [SerializeField]int itemNum;        �@//�g���܂킵�p�ϐ�

    [SerializeField] private Image target;

   public void TargetSet()
    {
       // �ڕW�A�C�e���ݒ�
         targetNum = Random.Range(0, ItemNumbers.Length);

        //�V�[���ɓo�ꂳ����ڕW�A�C�e��
        PushItem[0] = PrfbItems[targetNum];

        target.sprite = PushItem[0].GetComponent<SpriteRenderer>().sprite;

        //�p���[�A�b�v�A�C�e��
        itemNum = Random.Range(0, PowerItems.Length);
        PushItem[1] = PowerItems[itemNum];

        //���̑��v���C�Y
        for (int i = 0; i < PushItem.Length - 2; i++)
        {
            itemNum = Random.Range(0, ItemNumbers.Length);
            PushItem[i + 2] = PrfbItems[itemNum];
        }
    }
}
