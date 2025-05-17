using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestParticle : MonoBehaviour
{
    public static TestParticle Instance { get; private set; }
    enum State
    {
        TITLE = 0,
        GAMESCENE,
        RESULT,
    };

    [SerializeField] private GameObject particleParent;
    [SerializeField] private ParticleSystem fadeIn;
    [SerializeField] private ParticleSystem fadeOut;
    private State state = 0;

    [SerializeField] private GameObject fadeManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 重複したインスタンスを破棄
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            state = State.TITLE;
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            state = State.GAMESCENE;
        }
        else
        {
            state = State.RESULT;
        }
    }
    private void Update()
    {
        if (!IsPlaying.isPlay) { return; }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !UIHoverTracker.IsPointerOverButton)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "2_ResultScene")
            {
                fadeCall();
            }
        }
        //if (isFading)
        //{
        //    OptionCheck();
        //}
    }

    public void fadeCall()
    {
        StartCoroutine(fade());
    }

    private void OptionCheck()
    {
        GameObject btn = GameObject.Find("OptionButton");
        if(btn != null)btn.GetComponent<Button>().interactable = false;
        GameObject op = GameObject.Find("OptionCanvas");
        if (op != null)
        {
            op.SetActive(false);
        }
    }

    private IEnumerator fade()
    {
        IsPlaying.isPlay = false;
        OptionCheck();
        fadeIn.Play();
        yield return new WaitForSeconds(1.7f);
        OptionCheck();
        fadeOut.Play();
        //StartCoroutine(IsPlayDelay());
        if (state == State.TITLE)
        {
            SceneManager.GameLordScene();
        }
        else if (state == State.GAMESCENE)
        {
            SceneManager.GameOverLordScene();
        }
        else if (state == State.RESULT)
        {
            SceneManager.TitleLordScene();
        }
        state = state < State.RESULT ? state + 1 : State.TITLE;
        yield return new WaitForSeconds(2.5f);
        IsPlaying.isPlay = true;
    }
}
