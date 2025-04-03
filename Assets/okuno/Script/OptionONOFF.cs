using UnityEngine;

public class OptionONOFF : MonoBehaviour
{
    public static OptionONOFF Instance {  get; private set; }
    [SerializeField] private GameObject optionUi;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        optionUi.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.SelectSEPlay();
            if (IsPlaying.isPlay)
            {
                IsPlaying.isPlay = false;
                optionUi.SetActive(true);
            }
            else
            {
                IsPlaying.isPlay = true;
                optionUi.SetActive(false);
            }
        }
    }
}
