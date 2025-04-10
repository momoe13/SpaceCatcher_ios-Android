using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;

    [SerializeField]
    CameraManager cameraManager;

    //Toggleの値が変更されたときに呼び出される
    public void ChackToggle()
    {
        cameraManager.GetCheck(tabToggle.isOn);
    }

}
