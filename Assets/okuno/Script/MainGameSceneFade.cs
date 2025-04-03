using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneFade : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject fadeImage;
    [SerializeField] private GameObject fadeOutParticle;
    [SerializeField] private GameObject fadeInParticle;
    [Header("�Q�[���V�[���̂݃I��")]
    [SerializeField] private bool isGameScene;

    void Start()
    {
        //FadeIn();
    }

    private void Update()
    {
        // �f�o�b�O�p
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
    /// �X�R�A�Ȃǂ�UI�̕\��
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
    /// �t�F�[�h�A�E�g�p�F���F�̔w�i�\���Ǝ��Ԃ̒�~
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
    /// �t�F�[�h�A�E�g�p�F�p�[�e�B�N���I���ƃV�[���̃��[�h
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadSceneAfterWait()
    {
        fadeInParticle.SetActive(true);
        yield return new WaitForSeconds(2f);
        //SceneManager.GameLordScene();
    }
}
