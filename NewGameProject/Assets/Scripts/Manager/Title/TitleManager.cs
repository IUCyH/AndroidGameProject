using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingleTon<TitleManager>
{
    Action applicationQuitFunc;
    
    public void OnPressStartButton()
    {
        SceneLoadManager.Instance.LoadSceneAsync(Scenes.Lobby);
    }

    protected override void OnStart()
    {
        applicationQuitFunc = ApplicationQuit;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PopupManager.Instance.ShowPopup(PopupType.OkCancel, "Notice", "Do you want to quit this game?", "Yes", "No", applicationQuitFunc);
        }
    }

    void ApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
