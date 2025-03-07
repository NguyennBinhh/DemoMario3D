
using UnityEngine;

public class KeyInputEvent : MonoBehaviour
{
    [SerializeField] private GameObject FormSetting;

    private bool FrmSettingShow;

    private void Awake()
    {
        this.FrmSettingShow = false;
    }

    private void Update()
    {
        ESCOnClick();
    }

    public void ESCOnClick()
    {
        if (InputManager.Instance.EscKeyDown())
        {
            if (!this.FrmSettingShow)
                FormSetting.SetActive(true);
            else
                FormSetting.SetActive(false);
            this.FrmSettingShow = !this.FrmSettingShow;
        }
    }
}
