using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplication : SingletonMonoBehaviour<GameApplication>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
