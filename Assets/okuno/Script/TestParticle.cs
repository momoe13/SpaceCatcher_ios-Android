using System.Collections;
using UnityEngine;

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
    private bool isLoadScene = false;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "2_ResultScene" && !isLoadScene)
            {
                fadeCall();
                isLoadScene = true;
            }
        }
    }

    public void fadeCall()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        fadeIn.Play();
        yield return new WaitForSeconds(1.7f);
        fadeOut.Play();
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
            isLoadScene = false;
        }
        state = state < State.RESULT ? state + 1 : State.TITLE;
        yield return new WaitForSeconds(3.0f);
    }
}
