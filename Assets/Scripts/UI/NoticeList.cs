using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoticeList : MonoBehaviour
{
    [SerializeField] private Text noticeText;
    [SerializeField] private GameObject background;
    [SerializeField] private NoticeList noticeList; 
    

    void Start()
    {
        if (noticeText == null)
        {
            noticeText = GameObject.Find("Notice").GetComponent<Text>();
            
        }
        if (noticeList == null)
        {
            noticeList = GameObject.Find("NoticePanel").GetComponent<NoticeList>();
        }
        background.SetActive(false);
        
    }


    public void ShowNotice(InteractObject obj)
    {
        
        switch (obj)
        {
            case InteractObject.Key:
                background.SetActive(true);
                noticeText.text = "Press 'E' to get Key";
                break;
            case InteractObject.Ammo:
                background.SetActive(true);
                noticeText.text = "Press 'E' to get Ammo";
                break;
            case InteractObject.Heal:
                background.SetActive(true);
                noticeText.text = "Press 'E' to get Health";
                break;
            case InteractObject.Lock:
                background.SetActive(true);
                noticeText.text = "Press 'E' to unlock";
                break;
        }


    }
    public void AfterInteract(InteractObject obj)
    {
        switch (obj)
        {
            case InteractObject.Key:
                background.SetActive(true);
                noticeText.text = "Key obtained!";
                Invoke("HidePanel",1);
                break;
            case InteractObject.Ammo:
                background.SetActive(true);
                noticeText.text = "Obtain ammo!";
                Invoke("HidePanel", 1);
                break;
            case InteractObject.Heal:
                background.SetActive(true);
                noticeText.text = "You are healed!";
                Invoke("HidePanel", 1);
                break;
            case InteractObject.Lock:
                background.SetActive(true);
                noticeText.text = "Unlocked!";
                Invoke("HidePanel", 1);
                break;
        }
    }
    public void HidePanel()
    {
        noticeList.gameObject.SetActive(false);
    }
    public void DontHaveKey()
    {
        background.SetActive(true);
        noticeText.text = "You need key!";
        Invoke("HidePanel", 1);
    }

}
