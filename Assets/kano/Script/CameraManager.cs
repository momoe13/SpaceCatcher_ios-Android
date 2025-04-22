using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    int Size;
    bool Check;



    public void GetValue(int Value)
    {
        Size = Value;
        ChangeSize();
    }

    public void GetCheck(bool isOn)
    {
        Check = isOn;
        ChangeSize() ;
    }

    private void ChangeSize()
    {
        if (Check)
        {
            if (Size > 4) { mainCamera.orthographicSize = 9; }
            else { mainCamera.orthographicSize = 7; }
        }
        //スコアタブ消す
        else
        {
            if (Size > 4) { mainCamera.orthographicSize = 6; }
            else { mainCamera.orthographicSize = 5; }
        }
    }
}