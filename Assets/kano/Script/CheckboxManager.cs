using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;

    [SerializeField]
    CameraManager cameraManager;

    //Toggle‚Ì’l‚ª•ÏX‚³‚ê‚½‚Æ‚«‚ÉŒÄ‚Ño‚³‚ê‚é
    public void ChackToggle()
    {
        cameraManager.GetCheck(tabToggle.isOn);
    }

}
