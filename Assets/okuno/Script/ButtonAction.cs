using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject helpUI;
    [SerializeField] private GameObject option;

    public void ToggleHelpUI()
    {
        AudioManager.Instance.SelectSEPlay();
        if (helpUI.activeSelf)
        {
            helpUI.SetActive(false);
        }
        else
        {
            helpUI.SetActive(true);
        }
    }

    public void ToggleOptionButton()
    {
        AudioManager.Instance.SelectSEPlay();
        if (option == null)
        {
            option = GameObject.Find("OptionCanvas");
            if (option != null)
            {
                Debug.Log("Œ©‚Â‚©‚Á‚½");
            }
            else
            {
                Debug.Log("Œ©‚Â‚©‚ç‚È‚©‚Á‚½");
            }
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
