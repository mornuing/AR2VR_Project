using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    [Header("InputField")]
    [SerializeField] private TMP_InputField accountInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Space(5)]
    [Header("Password hide")]
    [SerializeField] private Image hideImage;
    [SerializeField] private Sprite hideIcon;
    [SerializeField] private Sprite showIcon;

    [Space(5)]
    [Header("Hint Text")]
    [SerializeField] private TMP_Text HintText;

    private bool isPasswordShow;
    private const string LOGIN_SUCCESS_TEXT = "<color=green>Login Success</color>";
    private const string LOGIN_FAIL_TEXT = "<color=red>Login Failed, check password or account again</color>";
    private const string EMPTY_CHECK_TEXT = "<color=red>Account or password is empty</color>";

    private const int LOGIN_RESULT_TEXT_SHOW_PERIOD = 3;
    private Coroutine HintCoroutine = null;
    void Start()
    {
        isPasswordShow = false;    
    }
    void OnDestroy()
    {
        if(HintCoroutine != null)
        {
            StopCoroutine(HintCoroutine);
            HintCoroutine = null;
        }
    }
    /// <summary>
    /// For exit button, would close the game immediately
    /// </summary>
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
    /// <summary>
    /// For login button, could check account and password is filled first
    /// </summary>
    public void OnLoginButtonClicked()
    {
        if(accountInput.text != string.Empty && passwordInput.text != string.Empty)
        {
            if(AuthManager.Instance.Auth(accountInput.text, passwordInput.text))
            {
                HintCoroutine = StartCoroutine(ShowHintText(LOGIN_SUCCESS_TEXT));                
            }
            else
            {
                HintCoroutine = StartCoroutine(ShowHintText(LOGIN_FAIL_TEXT));
            }
        }
        else
        {
            HintCoroutine = StartCoroutine(ShowHintText(EMPTY_CHECK_TEXT));
        }
    }
    /// <summary>
    /// For register button, could go to outer web or popup to regist
    /// </summary>
    public void OnRegisterButtonClicked()
    {
        // Show register page or outer url
    }
    /// <summary>
    /// For password show/hide, easy for user to check password
    /// </summary>
    public void OnPasswordHideButtonClicked()
    {
        if (isPasswordShow)
        {
            hideImage.sprite = hideIcon;
            passwordInput.contentType = TMP_InputField.ContentType.Password;
        }
        else
        {
            hideImage.sprite = showIcon;
            passwordInput.contentType = TMP_InputField.ContentType.Standard;            
        }
        passwordInput.ForceLabelUpdate();
        isPasswordShow = !isPasswordShow;
    }
    /// <summary>
    /// Forget password button, could go outer web or popup to send auth mail
    /// </summary>
    public void OnForgetPasswordButtonClicked()
    {
        // sent change password mail
    }

    private IEnumerator ShowHintText(string hint)
    {
        HintText.text = hint;
        HintText.gameObject.SetActive(true);
        if(hint == LOGIN_SUCCESS_TEXT)
        {
            yield return new WaitForSecondsRealtime(LOGIN_RESULT_TEXT_SHOW_PERIOD);
            GameSceneManager.Instance.LoadtoLoadingScene(Constants.SceneNames.CONTENT_SCENE); 
        }
        else
        {
            yield return new WaitForSecondsRealtime(LOGIN_RESULT_TEXT_SHOW_PERIOD);
            HintText.gameObject.SetActive(false);
        }
        yield return null;
    }
}