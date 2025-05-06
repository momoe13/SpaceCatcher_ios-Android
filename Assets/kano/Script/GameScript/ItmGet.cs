using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItmGet : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private TargetItem TargetItem;

    [SerializeField] private GameObject itemGetParticle;
    [SerializeField] private GeneratingManager generatingManager;
    [SerializeField] private GameObject turnManager;

    //-------加納
    [SerializeField] private Slider StarSlider;//星用バー
    int starCount = 0;//現在のスターの数
    [SerializeField] int maxStar;//スターの最大値
    [SerializeField] StarRemoveManager starRemove;
    [SerializeField] Sprite[] starGage;
    [SerializeField] Image starRender;
    //-------

    private void Start()
    {
        TargetItem.TargetSet();
        generatingManager.Generation();


        //----加納---
        StarSlider.maxValue = maxStar;//スライダーの最大値設定
        StarSlider.value = starCount;
        starRender.sprite = starGage[0];

        //----加納---
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////スター獲得
        if(collision.gameObject.tag == "Star"|| collision.gameObject.tag == "BasePowerUp"|| collision.gameObject.tag == "RatePowerUp"|| collision.gameObject.tag == "WidthPowerUp"|| collision.gameObject.tag == "TurnRecoveryUp"|| collision.gameObject.tag == "Target")
        {
            Destroy(Instantiate(itemGetParticle, collision.gameObject.transform.position, Quaternion.identity), 1.0f);
        }    
        //�X�^�[����ꂽ���̏���
        if (collision.gameObject.tag == "Star")
        {
            AddScoreOnDestroy(collision, 10);//�X�R�A��10�_���Z
            
            //----加納---
            starCount++;
            StarSlider.value = starCount;
            if (starCount == maxStar)
            {
                starRender.sprite = starGage[1];
                starRemove.AllRemoveStar();
                starCount = 0;
                StarSlider.value = starCount;
            }
            //----加納---
        }
        //��b�p���[�A�b�v�A�C�e������ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "BasePowerUp")
        {
            AudioManager.Instance.ItemGetSEPlay();
            crane.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            ScoreKeep.basePowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            AudioManager.Instance.ItemGetSEPlay();
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            ScoreKeep.ratePowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "WidthPowerUp")
        {
            AudioManager.Instance.ItemGetSEPlay();
            ScoreKeep.widthPowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�^�[���񕜐��A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            AudioManager.Instance.ItemGetSEPlay();
            turnManager.GetComponent<TurnManager>().ItemGetTurnCountUp();
            ScoreKeep.turnRecoveryUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            AudioManager.Instance.ItemGetSEPlay();
            AddScoreOnDestroy(collision, 1000);
            ScoreKeep.prizeScore += 1;

            if (TargetItem.PushItem[0].name + "(Clone)" == collision.gameObject.name)
            {
                TargetItem.TargetSet();
                generatingManager.Generation();
                turnManager.GetComponent<TurnManager>().TurnCountUp();
                ScoreKeep.score += 1000;
            }
        }
    }

    private void AddScoreOnDestroy(Collider2D collision, int addScore)
    {
        Destroy(collision.gameObject);
        ScoreKeep.score += addScore;//�X�R�A�����Z
    }
}
