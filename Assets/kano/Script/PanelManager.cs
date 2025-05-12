using UnityEngine;
using UnityEngine.UI;
public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] BannerManager bannerManager;

    public void GetCancel()
    {
        Panel.SetActive(false);
        bannerManager.HideBannerAd();
    }

}
