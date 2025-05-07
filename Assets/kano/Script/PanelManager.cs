using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void GetCancel()
    {
        Panel.SetActive(false);
    }

}
