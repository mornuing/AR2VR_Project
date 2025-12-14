using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager>
{
    private string _nextSceneName;
    private Action _callback;
    public AsyncOperation asyncOperation = null;

    private void Start()
    {
        LoadtoLoadingScene(Constants.SceneNames.LOGIN_SCENE);
    }

    /// <summary>
    /// Every change scene should set to loading scene 
    /// </summary>
    /// <param name="TargetSceneName">target scene</param>
    /// <param name="callback">all function should finish after scene complete</param>
    public void LoadtoLoadingScene(string TargetSceneName, Action callback = null)
    {
        _nextSceneName = TargetSceneName;
        _callback = callback;
        StartCoroutine(LoadtoLoadingScene());
    }

    public void StartLoadingNextScene(LoadingScreen loadingScreen)
    {
        StartCoroutine(LoadNextScene(loadingScreen));
    }

    private IEnumerator LoadtoLoadingScene()
    {
        yield return SceneManager.LoadSceneAsync(Constants.SceneNames.LOADING_SCENE, LoadSceneMode.Single);
    }

    private IEnumerator LoadNextScene(LoadingScreen loadingScreen)
    {
        yield return null;
        asyncOperation = SceneManager.LoadSceneAsync(_nextSceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        asyncOperation.completed += obj =>
        {
            _callback?.Invoke();
        };

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                loadingScreen.OnNextSceneLoadFinish();
                yield return new WaitUntil(() => loadingScreen.isLoadingProgressFinish);
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
