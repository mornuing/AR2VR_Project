using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonMonoBehaviour<GameDataManager>
{
    private UserAccount userAccount;

    /// <summary>
    /// Set up data and could save more data further
    /// </summary>
    /// <param name="userAccount"></param>
    public void SetUserAccount(UserAccount userAccount)
    {
        this.userAccount = userAccount;
    }
}
public struct UserAccount
{
    public string account;
    public string password;
}