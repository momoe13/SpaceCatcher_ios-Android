using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager : MonoBehaviour
{
    [SerializeField]
    Toggle tabToggle;

    GameObject camera;
    CameraManager cameraManager;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        cameraManager = camera.GetComponent<CameraManager>();
    }

    //Toggle‚Ì’l‚ª•ÏX‚³‚ê‚½‚Æ‚«‚ÉŒÄ‚Ño‚³‚ê‚é
    public void ChackToggle()
    {
        cameraManager.GetCheck(tabToggle.isOn);
    }

}
