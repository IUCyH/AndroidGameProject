using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingleTon<TitleManager>
{
    public void OnPressStartButton()
    {
        SceneLoadManager.Instance.LoadSceneAsync(Scenes.Lobby);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PopupManager.Instance.ShowPopup(PopupType.OkCancel, "Notice", "Do you want to quit this game?", "Yes", "No", () => { Application.Quit(); });
        }
    }
}
