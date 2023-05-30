using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using UnityEngine;

public class LoginManager : SingleTon<LoginManager>
{
    [SerializeField]
    TextMeshProUGUI loginText;

    const string LogIn = "Log In";
    const string LogOut = "Log Out";

    bool IsLogin => PlayGamesPlatform.Instance.localUser.authenticated;
    
    #if UNITY_EDITOR
    protected override void OnStart()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Login();
    }

    void Login()
    {
        if (!IsLogin)
        {
            Social.localUser.Authenticate(success =>
            {
                if (success)
                {
                    loginText.text = LogOut;
                }
                else
                {
                    loginText.text = LogIn;
                }
            });
        }
    }

    public void OnPressLogoutButton()
    {
        if (IsLogin)
        {
            ((PlayGamesPlatform)Social.Active).SignOut();
        }
        else
        {
            Login();
        }
    }
#endif
}
