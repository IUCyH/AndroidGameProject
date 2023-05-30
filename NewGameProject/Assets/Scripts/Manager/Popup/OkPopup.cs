using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OkPopup : MonoBehaviour, IPopup
{
    Action actionWhenPressOkButton;
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI content;
    [SerializeField]
    TextMeshProUGUI okBtnTMP;

    const PopupType ThisPopupType = PopupType.Ok;

    public PopupType Type => ThisPopupType;
    
    public void SetPopup(string titleText, string contentText, string okBtnText = "OK", string cancelBtnText = "Cancel", Action okFunc = null)
    {
        title.text = titleText;
        content.text = contentText;
        okBtnTMP.text = okBtnText;
        
        actionWhenPressOkButton = okFunc;
    }
    
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        if (actionWhenPressOkButton != null)
        {
            actionWhenPressOkButton();
        }
        
        gameObject.SetActive(false);
    }
    
    public void OnPressOkButton()
    {
        PopupManager.Instance.HidePopup();
    }
}
