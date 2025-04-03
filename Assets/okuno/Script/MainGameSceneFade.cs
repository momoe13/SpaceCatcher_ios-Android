using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneFade : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject fadeImage;
    [SerializeField] private GameObject fadeOutParticle;
    [SerializeField] private GameObject fadeInParticle;
    [Header("ゲームシーンのみオン")]
    [SerializeField] private bool isGameScene;

    void Start()
    {
        //FadeIn();
    }

    private void Update()
    {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.T))
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        fadeImage.SetActive(true);
        fadeOutParticle.SetActive(true);
        StartCoroutine(CanvasOnAfterWait());
    }

    public void FadeOut()
    {
        StartCoroutine(LoadSceneImageOn());
        StartCoroutine(LoadSceneAfterWait());
        if (!isGameScene) { return; }
        StartCoroutine(ScoreUiOff());
    }

    /// <summary>
    /// スコアなどのUIの表示
    /// </summary>
    /// <returns></returns>
    private IEnumerator CanvasOnAfterWait()
    {
        if (isGameScene)
        {
            uiCanvas.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
        fadeImage.SetActive(false);
        if (isGameScene)
        {
            yield return new WaitForSeconds(1.5f);
            uiCanvas.SetActive(true);
        }
    }

    /// <summary>
    /// フェードアウト用：黄色の背景表示と時間の停止
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadSceneImageOn()
    {
        yield return new WaitForSeconds(1.55f);
        fadeImage.SetActive(true);
        Time.timeScale = 0;
        if (isGameScene)
        {
            SceneManager.GameOverLordScene();
        }
    }

    private IEnumerator ScoreUiOff()
    {
        yield return new WaitForSeconds(0.2f);
        uiCanvas.SetActive(false);
    }

    /// <summary>
    /// フェードアウト用：パーティクルオンとシーンのロード
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadSceneAfterWait()
    {
        fadeInParticle.SetActive(true);
        yield return new WaitForSeconds(2f);
        //SceneManager.GameLordScene();
    }
}
