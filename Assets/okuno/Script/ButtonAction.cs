using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject helpUI;
    [SerializeField] private GameObject option;

    public void ToggleHelpUI()
    {
        AudioManager.Instance.SelectSEPlay();
        helpUI.SetActive(!helpUI.activeSelf);
    }

    public void ToggleOptionButton()
    {
        AudioManager.Instance.SelectSEPlay();
        if (option == null)
        {
            option = GameObject.Find("OptionCanvas");
        }
        if (option != null)
        {
            if (option.activeSelf)
            {
                IsPlaying.isPlay = true;
                option.SetActive(false);
            }
            else
            {
                IsPlaying.isPlay = false;
                option.SetActive(true);
            }
        }
    }
}
