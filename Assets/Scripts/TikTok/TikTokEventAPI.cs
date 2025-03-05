using System;
using System.Collections.Generic;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Events;
using TikTokLiveSharp.Events.Objects;
using TikTokLiveUnity;
using UnityEngine;


public class TikTokEventAPI : MonoBehaviour
{
    [SerializeField] private string userId;
    [SerializeField] private Dictionary<string, object> paramsClient;
    [SerializeField] public static TikTokEventAPI instance;
    [SerializeField] public event Action<string, long, long> ReceiveGift;
    [SerializeField] public event Action OnLike;
    [SerializeField] public event Action<string, string> Comment;

    private bool isConnect;
    protected void Awake()
    {

        //UserId = "locfuho1995";
        if (TikTokEventAPI.instance != null)
        {
            Debug.LogWarning("Only One TikTokEventAPI allow to exists");
            Destroy(TikTokEventAPI.instance);
        }
           
        TikTokEventAPI.instance = this;
        
        DontDestroyOnLoad(gameObject);
        
    }
   
    public async void ConnectToLive()
    {
     
        GameObject.Find("Canvas").GetComponent<ButtonConnect>().MessageBox("Connecting...");
        await TikTokLiveManager.Instance.ConnectToStream(PlayerPrefs.GetString("UserIDTikTok"), exception => { }, paramsClient);
        
        this.SignEvent(); // Đăng ký sự kiện mới
       
        isConnect = true;
    }
    
    protected void SignEvent()
    {
        TikTokLiveManager.Instance.OnConnected += (liveClient, isConnect) =>
        {
            Debug.Log("Kết nối thành công!");
            GameObject.Find("Canvas").GetComponent<ButtonConnect>().MessageBox("Connected!");
        };
        TikTokLiveManager.Instance.OnLike += (liveClient, likeEvent) =>
        {
            Debug.Log($"Event Like:\n {likeEvent.Count} {likeEvent.Sender.NickName}");
            this.HanleEventLike(liveClient, likeEvent);
        };
        TikTokLiveManager.Instance.OnGift += (liveClient, giftEvent) =>
        {
            Debug.Log($"Event Gift:\n {giftEvent.Gift.Name} {giftEvent.Sender.NickName}");
            Debug.Log($"Số lượng:  { giftEvent.Amount} : {giftEvent.Gift.Id}");
            this.HanleEventGift(liveClient, giftEvent);
        };
        TikTokLiveManager.Instance.OnChatMessage += (liveClient, commentEvent) =>
        {
           Debug.Log($"Event Chat:\n {commentEvent.Message} {commentEvent.Sender.NickName}");
           this.HanleEventComment(liveClient, commentEvent);
        };
    }

    private void HanleEventGift(TikTokLiveClient liveClient, TikTokGift tiktokgift)
    {
       
         this.ReceiveGift?.Invoke(tiktokgift.Gift.Name, tiktokgift.Amount, tiktokgift.Gift.Id);

    }
    private void HanleEventComment(TikTokLiveClient liveClient, Chat chat)
    {

        this.Comment?.Invoke(chat.Sender.NickName, chat.Message);
    }
    private void HanleEventLike(TikTokLiveClient liveClient, Like tiktokLike)
    {
        this.OnLike?.Invoke();
    }
}
