using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    int Size;
    bool Check;


    [SerializeField]//目標解像度
    Vector2 aspectVec;

    private void Update()
    {
        var screenAspect = Screen.width / (float)Screen.height; //画面のアスペクト比
        var targetAspect = aspectVec.x / aspectVec.y; //目的のアスペクト比

        var magRate = targetAspect / screenAspect; //目的アスペクト比にするための倍率

        var viewportRect = new Rect(0, 0, 1, 1); //Viewport初期値でRectを作成

        if (magRate < 1)
        {
            viewportRect.width = magRate; //使用する横幅を変更
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;//中央寄せ
        }
        else
        {
            viewportRect.height = 1 / magRate; //使用する縦幅を変更
            viewportRect.y = 0.5f - viewportRect.height * 0.5f;//中央余生
        }

        mainCamera.rect = viewportRect; //カメラのViewportに適用
    }

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