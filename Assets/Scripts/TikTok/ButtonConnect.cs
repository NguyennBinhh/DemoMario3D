using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonConnect : MonoBehaviour
{

    /// <summary>
    /// Chưa xử lý được login nhiều lần hoặc thay đổi ID like
    /// </summary>
    
    [SerializeField] private TMP_InputField txt_UID;  
    [SerializeField] private TextMeshProUGUI txt_Message;
    private void Awake()
    {
        
    }
    public void MessageBox(string msg)
    {
        txt_Message.text = msg;
    }

    public void ResetTextFrmLogin()
    {
        txt_Message.text = "";
        txt_UID.text = "";
    }
    public void btnConnect()
    {
        string UID = txt_UID.text;

        if (string.IsNullOrEmpty(UID))
        {
            txt_Message.text = "Nhập UID TikTok!";
            return;
        }

        PlayerPrefs.SetString("UserIDTikTok", UID);
        TikTokEventAPI.instance.ConnectToLive();
    }
}
