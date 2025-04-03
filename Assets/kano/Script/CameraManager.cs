using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    int Size;
    bool Check;
    public static CameraManager Instance { get; private set; }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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