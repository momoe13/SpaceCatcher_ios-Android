using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("AudioSource")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource craneSeSource;
    [SerializeField] private AudioSource normalSeSource;

    [Header("--------BGM--------")]
    [Header("タイトル")]
    [SerializeField] private AudioClip title;
    [SerializeField] public float titleBGMBaseVolume;
    [Header("ゲーム")]
    [SerializeField] private AudioClip game;
    [SerializeField] private float gameBGMBaseVolume;
    [Header("リザルト")]
    [SerializeField] private AudioClip result;
    [SerializeField] private float resultBGMBaseVolume;
    [Header("--------SE--------")]
    [Header("セレクト")]
    [SerializeField] private AudioClip select;
    [SerializeField] private float selectSeBaseVolume;
    [Header("画面遷移SE")]
    [SerializeField] private AudioClip fade;
    [SerializeField] private float fadeSeBaseVolume;
    [Header("クレーンSE")]
    [SerializeField] private AudioClip craneDown;
    [SerializeField] private AudioClip craneUp;
    [SerializeField] private float craneSeBaseVolume;
    [Header("アイテム獲得")]
    [SerializeField] private AudioClip itemGet;
    [SerializeField] private float itemGetSeBaseVolume;

    [Header("オプション用Slider")]
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    private float currentBGMBaseVolume;
    private float currentSEBaseVolume;
    private float currentCraneSEBaseVolume;

    public const string audioBGMValueKey = "BGMValue";
    public const string audioSEValueKey = "SEValue";

    private bool isTitleBgm = false;
    private bool isGameBgm = false;
    private bool isResultBgm = false;

    private const string BGMVolume = "BGMVolume";
    private const string SEVolume = "SEVolume";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //第二引数にはセットする値
    }

    private void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat(BGMVolume,1f);
        seSlider.value = PlayerPrefs.GetFloat(SEVolume, 1f);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
        //クレーンのSEもSEのSlider変更時に一緒に変更されるように
        seSlider.onValueChanged.AddListener(SetCraneSEVolume);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            TitleBGMPlay();
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            //ゲームBGM再生
            GameBGMPlay();
        }
        else
        {
            //リザルトBGM再生
            //ResultBGMPlay();
            StopIfPlaying(bgmSource);
        }
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            if (!isTitleBgm)
            {
                TitleBGMPlay();
            }
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            if (!isGameBgm)
            {
                GameBGMPlay();
            }
        }
        else
        {
            if (!isResultBgm)
            {
                //ResultBGMPlay();
                StopIfPlaying(bgmSource);
            }
        }
    }

    /*--------------------------------------BGM--------------------------------------*/

    public void SetBGMVolume(float value)
    {
        // 現在の音量から相対的に変化
        float newVolume = currentBGMBaseVolume * value;

        // 音量設定と保存
        UpdateBGMVolume(newVolume);
    }


    public void TitleBGMPlay()
    {
        //再生中なら止める
        StopIfPlaying(bgmSource);
        isTitleBgm = true;
        currentBGMBaseVolume = titleBGMBaseVolume;

        //Sliderの値を参照し、音量を確実にセットする。
        SetBGMVolume(bgmSlider.value);
        //AudioSurceのClipにタイトルのClipを格納
        bgmSource.clip = title;
        bgmSource.Play();
    }

    public void GameBGMPlay()
    {
        StopIfPlaying(bgmSource);
        isGameBgm = true;
        currentBGMBaseVolume = gameBGMBaseVolume;
        SetBGMVolume(bgmSlider.value);
        bgmSource.clip = game;
        bgmSource.Play();
    }

    //public void ResultBGMPlay()
    //{
    //    StopIfPlaying(bgmSource);
    //    isResultBgm = true;
    //    currentBGMBaseVolume = resultBGMBaseVolume;
    //    bgmSource.volume = currentBGMBaseVolume;
    //    bgmSource.clip = result;
    //    bgmSource.Play();
    //}
    /*--------------------------------------SE--------------------------------------*/
    public void SetSEVolume(float value)
    {
        // 現在の音量から相対的に変化
        float newVolume = currentSEBaseVolume * value;

        // 音量設定と保存
        UpdateSEVolume(newVolume);
    }

    public void SetCraneSEVolume(float value)
    {
        // 現在の音量から相対的に変化
        float newVolume = currentCraneSEBaseVolume * value;

        // 音量設定と保存
        UpdateCraneSEVolume(newVolume);
    }

    public void SelectSEPlay()
    {
        currentSEBaseVolume = selectSeBaseVolume;
        SetSEVolume (seSlider.value);
        normalSeSource.clip = select;
        normalSeSource.PlayOneShot(normalSeSource.clip);
    }

    public void CraneDownSEPlay()
    {
        currentCraneSEBaseVolume = craneSeBaseVolume;
        SetCraneSEVolume (seSlider.value);
        craneSeSource.clip = craneDown;
        craneSeSource.Play();
    }

    public void CraneUpSEPlay()
    {
        currentCraneSEBaseVolume = craneSeBaseVolume;
        SetCraneSEVolume(seSlider.value);
        craneSeSource.clip = craneUp;
        craneSeSource.Play();
    }

    public void ItemGetSEPlay()
    {
        currentSEBaseVolume = itemGetSeBaseVolume;
        SetSEVolume (seSlider.value);
        normalSeSource.clip = itemGet;
        normalSeSource.PlayOneShot(normalSeSource.clip);
    }

    /// <summary>
    /// クレーン降下時と上昇時にループで再生するようになってるから、止める用
    /// </summary>
    public void StopCraneSEPlay()
    {
        craneSeSource.Stop();
    }

    /*----------音量を実際に変更する----------*/
    public void UpdateBGMVolume(float newVolume)
    {
        bgmSource.volume = newVolume;
        PlayerPrefs.SetFloat(BGMVolume, bgmSlider.value);
        PlayerPrefs.Save();
    }

    public void UpdateSEVolume(float newVolume)
    {
        normalSeSource.volume = newVolume;
        PlayerPrefs.SetFloat(SEVolume, seSlider.value);
        PlayerPrefs.Save();
    }

    public void UpdateCraneSEVolume(float newVolume)
    {
        craneSeSource.volume = newVolume;
    }

    /// <summary>
    /// 引数のAudioSourceでなにか再生していた場合、止める
    /// </summary>
    /// <param name="audioSourceName"></param>
    private void StopIfPlaying(AudioSource audioSourceName)
    {
        if (audioSourceName.isPlaying)
        {
            isTitleBgm = false;
            isGameBgm = false;
            isResultBgm = false;
            audioSourceName.Stop();
        }
    }
}
