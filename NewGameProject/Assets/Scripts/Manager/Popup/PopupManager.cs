using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PopupType
{
    None = -1,
    Ok,
    OkCancel,
    InputField,
    Max
}

public class PopupManager : SingleTon_DontDestroy<PopupManager>
{
    [SerializeField]
    Image preventTouch;
    [SerializeField]
    Canvas canvas;
    Dictionary<PopupType, ObjectPool<IPopup>> popupPoolDic = new Dictionary<PopupType, ObjectPool<IPopup>>();
    Stack<IPopup> popupStack = new Stack<IPopup>();

    public void ShowPopup(PopupType type, string titleText, string contentText, string okBtnText = "OK", string cancelBtnText = "Cancel", Action okFunc = null)
    {
        var popup = popupPoolDic[type].Get();
        popup.SetPopup(titleText, contentText, okBtnText, cancelBtnText, okFunc);

        popup.Open();
        popupStack.Push(popup);
        SetActivePreventClick(true);
    }

    public void HidePopup()
    {
        var popup = popupStack.Pop();

        if (popup != null)
        {
            popup.Close();
            popupPoolDic[popup.Type].Set(popup);

            if (popupStack.Count < 1)
            {
                SetActivePreventClick(false);
            }
        }
    }

    protected override void OnStart()
    {
        var prefabs = Resources.LoadAll<GameObject>("Prefab");
        var length = prefabs.Length;

        for (int i = 0; i < length; i++)
        {
            var popup = prefabs[i];
            
            popupPoolDic.Add((PopupType)i, new ObjectPool<IPopup>(3,() =>
            {
                var obj = Instantiate(popup);
                obj.transform.SetParent(canvas.transform);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localScale = Vector3.one;
                
                obj.SetActive(false);

                return obj.GetComponent<IPopup>();
            }));
        }

        SetActivePreventClick(false);
    }

    void SetActivePreventClick(bool value)
    {
        preventTouch.enabled = value;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            ShowPopup(PopupType.OkCancel, "Test", "Woooow it's test!");
        }
    }
}
