using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    private const float FAKE_PROGRESS_BAR_RANDOM_LOWER_BOUND = .01f;
    private const float FAKE_PROGRESS_BAR_RANDOM_UPPER_BOUND = .05f;
    private const float FAKE_PROGRESS_BAR_UPDATE_TIME = .1f;
    
    private Coroutine fakeLoadingCor = null;
    private bool isNextSceneLoadFinish;
    public bool isLoadingProgressFinish { get;private set; }
    private void Start()
    {
        progressBar.value = 0;
        isNextSceneLoadFinish = false;
        isLoadingProgressFinish = false;
        GameSceneManager.Instance.StartLoadingNextScene(this);
        fakeLoadingCor = StartCoroutine(FakeLoading());
    }
    private void OnDestroy()
    {
        if(fakeLoadingCor != null)
        {
            StopCoroutine(fakeLoadingCor);
            fakeLoadingCor = null;
        }
    }
    public void OnNextSceneLoadFinish()
    {
        isNextSceneLoadFinish = true;
        Debug.LogError("Next Scene Load Finish");
    }
    private IEnumerator FakeLoading()
    {
        while (progressBar.value < 1f || !isNextSceneLoadFinish) 
        {
            if(progressBar.value >= .9f)
            {
                progressBar.value = 1f;
                isLoadingProgressFinish = true;
                break;
            }
            else
            {
                progressBar.value += Random.Range(FAKE_PROGRESS_BAR_RANDOM_LOWER_BOUND, FAKE_PROGRESS_BAR_RANDOM_UPPER_BOUND);
                yield return new WaitForSecondsRealtime(FAKE_PROGRESS_BAR_UPDATE_TIME);
            }
        }
        yield return null;
    }
}
