using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField accountInput;
    [SerializeField] private TMP_InputField passwordInput;

    [SerializeField] private Image hideImage;
    [SerializeField] private Sprite hideIcon;
    [SerializeField] private Sprite showIcon;
    private bool isPasswordShow;
    
    void Start()
    {
        isPasswordShow = false;    
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
    public void OnLoginButtonClicked()
    {
        
    }
    public void OnRegisterButtonClicked()
    {
        
    }
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
    public void OnForgetPasswordButtonClicked()
    {
        
    }
}
