using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameAction()
    {
        AudioManager.Instance.SelectSEPlay();
#if UNITY_EDITOR
        // Unityエディタ上ではプレイモードを終了
        UnityEditor.EditorApplication.isPlaying = false;

#elif UNITY_STANDALONE
            // Windows / Mac などのPC向け
            Application.Quit();

#elif UNITY_ANDROID
            // Androidは普通に終了できる
            Application.Quit();

#elif UNITY_IOS
            // iOSでは終了を明示的に行わない方がよい
            Debug.Log("iOSではアプリを明示的に終了できない");
#elif UNITY_WEBGL
　　　　　　// WebGLではそのページをリロード
　　　　　　Application.OpenURL(Application.absoluteURL);
#endif
    }
}
