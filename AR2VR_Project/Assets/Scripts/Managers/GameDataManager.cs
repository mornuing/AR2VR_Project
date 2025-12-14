using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonMonoBehaviour<GameDataManager>
{
    private UserAccount userAccount;

    public void SetUserAccount(UserAccount userAccount)
    {
        this.userAccount = userAccount;
        Debug.LogError($"{userAccount.account} {userAccount.password}");
    }
}
public struct UserAccount
{
    public string account;
    public string password;
}