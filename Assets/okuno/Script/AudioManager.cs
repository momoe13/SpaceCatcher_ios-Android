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
    [Header("�^�C�g��")]
    [SerializeField] private AudioClip title;
    [SerializeField] public float titleBGMBaseVolume;
    [Header("�Q�[��")]
    [SerializeField] private AudioClip game;
    [SerializeField] private float gameBGMBaseVolume;
    [Header("���U���g")]
    [SerializeField] private AudioClip result;
    [SerializeField] private float resultBGMBaseVolume;
    [Header("--------SE--------")]
    [Header("�Z���N�g")]
    [SerializeField] private AudioClip select;
    [SerializeField] private float selectSeBaseVolume;
    [Header("��ʑJ��SE")]
    [SerializeField] private AudioClip fade;
    [SerializeField] private float fadeSeBaseVolume;
    [Header("�N���[��SE")]
    [SerializeField] private AudioClip craneDown;
    [SerializeField] private AudioClip craneUp;
    [SerializeField] private float craneSeBaseVolume;
    [Header("�A�C�e���l��")]
    [SerializeField] private AudioClip itemGet;
    [SerializeField] private float itemGetSeBaseVolume;

    [Header("�I�v�V�����pSlider")]
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

        //�������ɂ̓Z�b�g����l
    }

    private void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat(BGMVolume,1f);
        seSlider.value = PlayerPrefs.GetFloat(SEVolume, 1f);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
        //�N���[����SE��SE��Slider�ύX���Ɉꏏ�ɕύX�����悤��
        seSlider.onValueChanged.AddListener(SetCraneSEVolume);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            TitleBGMPlay();
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            //�Q�[��BGM�Đ�
            GameBGMPlay();
        }
        else
        {
            //���U���gBGM�Đ�
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
        // ���݂̉��ʂ��瑊�ΓI�ɕω�
        float newVolume = currentBGMBaseVolume * value;

        // ���ʐݒ�ƕۑ�
        UpdateBGMVolume(newVolume);
    }


    public void TitleBGMPlay()
    {
        //�Đ����Ȃ�~�߂�
        StopIfPlaying(bgmSource);
        isTitleBgm = true;
        currentBGMBaseVolume = titleBGMBaseVolume;

        //Slider�̒l���Q�Ƃ��A���ʂ��m���ɃZ�b�g����B
        SetBGMVolume(bgmSlider.value);
        //AudioSurce��Clip�Ƀ^�C�g����Clip���i�[
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
        // ���݂̉��ʂ��瑊�ΓI�ɕω�
        float newVolume = currentSEBaseVolume * value;

        // ���ʐݒ�ƕۑ�
        UpdateSEVolume(newVolume);
    }

    public void SetCraneSEVolume(float value)
    {
        // ���݂̉��ʂ��瑊�ΓI�ɕω�
        float newVolume = currentCraneSEBaseVolume * value;

        // ���ʐݒ�ƕۑ�
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
    /// �N���[���~�����Ə㏸���Ƀ��[�v�ōĐ�����悤�ɂȂ��Ă邩��A�~�߂�p
    /// </summary>
    public void StopCraneSEPlay()
    {
        craneSeSource.Stop();
    }

    /*----------���ʂ����ۂɕύX����----------*/
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
    /// ������AudioSource�łȂɂ��Đ����Ă����ꍇ�A�~�߂�
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
