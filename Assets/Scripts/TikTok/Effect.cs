using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    [SerializeField] private Player player_script;
    [SerializeField] private ItemManager ItemManager;
    private void Awake()
    {
        if (TikTokEventAPI.instance != null)
        {
            TikTokEventAPI.instance.OnLike += this.EventTikTokTym; ///Like
            TikTokEventAPI.instance.ReceiveGift += this.EventSendGift; /// Tặng quà 
            TikTokEventAPI.instance.Comment += this.EventSendCmt;
        }
        player_script = GetComponent<Player>();
        ItemManager = GetComponent<ItemManager>();
    }

    private void EventTikTokTym()
    {
        if (player_script.currentspeed > 20)
            player_script.currentspeed = 20;

    }

    private void EventSendCmt(string name, string cmt)
    {
        if(cmt.Equals("666"))
        {
            this.ItemManager.current_Item = "";
            StartCoroutine(this.ItemManager.UseBullet());
        }    
    }
    
    private void EventSendGift(string name, long count, long  giftId)
    {
        if (name.Equals("Rose") || giftId == 5655) /// 1 xu - Ném banana
        {
            player_script.Driver.SetTrigger("ThrowForward");
            this.ItemManager.StartCoroutine(this.ItemManager.spawnBanana(2));

        }

        else if (name.Equals("TikTok") || giftId == 5650) /// 1 xu - nhận vàng
        {
            for (int i = 0; i < count; i++)
            {
                this.ItemManager.current_Item = "";
                this.ItemManager.used_Item_Done();
                StartCoroutine(this.ItemManager.UseCoin());
            }
        }

        else if (name.Equals("Okay") || giftId == 5636) /// 5 xu - Bị choáng
        {
            for (int i = 0; i < count; i++)
            {
                StartCoroutine(this.player_script.hitByBanana());
               
            }
        }
        else if (name.Equals("Doughnut") || giftId == 5619) /// 30 xu - sử dụng tên lừa
        {
            this.ItemManager.current_Item = "";
            StartCoroutine(this.ItemManager.UseBullet());
        }
        else if (name.Equals("Love Bang") || giftId == 5671) /// 20 xu - Buff miễn nhiễm 
        {
            this.ItemManager.current_Item = "";
            this.ItemManager.used_Item_Done();
            StartCoroutine(this.ItemManager.UseStar());
        }
        else if (name.Equals("Shamrock") ) /// 10 xu - Buff boost trong 4 giây
        {
            this.ItemManager.UseBoostSpeed(4f);
        }

        else if (name.Equals("Ice cream") ) /// 5 xu - Ném bom
        {
            for (int i = 0; i < count; i++)
            {
                this.ItemManager.current_Item = "";
                this.ItemManager.used_Item_Done();
                StartCoroutine(this.ItemManager.useBobomb(1));
            }
        } 
        else if(name.Equals("Finger heart")) /// 5 xu - Bị lật xe
        {
            this.player_script.Shellhit();
        }   
        
           
            
    }

}
