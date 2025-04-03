using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;

    [SerializeField]
    CameraManager cameraManager;

    //Toggle�̒l���ύX���ꂽ�Ƃ��ɌĂяo�����
    public void ChackToggle()
    {
        cameraManager.GetCheck(tabToggle.isOn);
    }

}
