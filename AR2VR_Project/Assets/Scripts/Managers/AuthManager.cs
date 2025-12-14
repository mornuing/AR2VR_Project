using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthManager : SingletonMonoBehaviour<AuthManager>
{
    private bool allowAllAccount = true;
    public void Auth(LoginScreen loginScreen, string account, string password = "")
    {
        // auth check 
        // if success => login else ignore
        if (allowAllAccount)
        {
            UserAccount userAccount = new UserAccount
            {
                account = account,
                password = password
            };
            GameDataManager.Instance.SetUserAccount(userAccount);
            GameSceneManager.Instance.LoadtoLoadingScene(Constants.SceneNames.CONTENT_SCENE);
        }
    }
}
